resource "aws_secretsmanager_secret" "jwt_secret_key" {
  name        = "creditflow-jwt-secret-key"
  description = "Credenciais do banco RDS PostgreSQL"
}

resource "aws_secretsmanager_secret_version" "jwt_secret_key_version" {
  secret_id     = aws_secretsmanager_secret.jwt_secret_key.id
  secret_string = jsonencode({
    jwt_secret_key = var.jwt_secret_key
  })
}
