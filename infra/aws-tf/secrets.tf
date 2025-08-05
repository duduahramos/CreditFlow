resource "aws_secretsmanager_secret" "jwt_secret_key" {
  name        = "creditflow-jwt-secret-key"
  description = "Credenciais do banco RDS PostgreSQL"
}

resource "aws_secretsmanager_secret_version" "jwt_secret_key_version" {
  secret_id = aws_secretsmanager_secret.jwt_secret_key.id
  secret_string = jsonencode({
    jwt_secret_key = var.jwt_secret_key
  })
}

resource "aws_secretsmanager_secret" "pwd_salt" {
  name        = "creditflow-pwd-salt"
  description = "Salt para senhas da aplicação"
}

resource "aws_secretsmanager_secret_version" "pwd_salt_version" {
  secret_id = aws_secretsmanager_secret.pwd_salt.id
  secret_string = jsonencode({
    pwd_salt = var.pwd_salt
  })
}
