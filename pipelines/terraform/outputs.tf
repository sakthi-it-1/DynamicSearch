output "webapp_url" {
  value = azurerm_app_service.webapp.default_site_hostname
}

output "key_vault_uri" {
  value = azurerm_key_vault.kv.vault_uri
}