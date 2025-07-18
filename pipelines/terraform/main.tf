provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  name     = "rg-sakthi-demo"
  location = "East US"
}

resource "azurerm_key_vault" "kv" {
  name                = "kv-sakthi-demo"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  tenant_id           = data.azurerm_client_config.current.tenant_id
  sku_name            = "standard"

  access_policy {
    tenant_id = data.azurerm_client_config.current.tenant_id
    object_id = data.azurerm_client_config.current.object_id

    secret_permissions = ["get", "set", "list"]
  }
}

data "azurerm_client_config" "current" {}

resource "azurerm_mssql_server" "sql" {
  name                         = "sql-sakthi-demo"
  resource_group_name          = azurerm_resource_group.rg.name
  location                     = azurerm_resource_group.rg.location
  version                      = "12.0"
  administrator_login          = "sqladmin"
  administrator_login_password = "P@ssword1234"

  azuread_administrator {
    login_username = "sakthi-admin"
    object_id      = data.azurerm_client_config.current.object_id
  }
}

resource "azurerm_mssql_database" "db" {
  name      = "sakthi-db"
  server_id = azurerm_mssql_server.sql.id
  sku_name  = "S0"
}

resource "azurerm_app_service_plan" "asp" {
  name                = "asp-sakthi-demo"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  kind                = "Windows"
  reserved            = false

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "webapp" {
  name                = "webapp-sakthi-demo"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.asp.id

  identity {
    type = "SystemAssigned"
  }

  app_settings = {
    "ConnectionStrings__Database" = "Server=${azurerm_mssql_server.sql.fully_qualified_domain_name};Authentication=Active Directory Default;Database=${azurerm_mssql_database.db.name};Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}

resource "azurerm_key_vault_secret" "sql_conn" {
  name         = "sql-connectionstring"
  value        = azurerm_app_service.webapp.app_settings["ConnectionStrings__Database"]
  key_vault_id = azurerm_key_vault.kv.id
}