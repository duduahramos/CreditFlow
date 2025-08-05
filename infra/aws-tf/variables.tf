variable "db_username" {
  description = "Usuário administrador do banco"
  type        = string
  sensitive   = true
}

variable "db_password" {
  description = "Senha do usuário administrador do banco"
  type        = string
  sensitive   = true
}

variable "aws_region" {
  description = "Região aws"
  type        = string
  sensitive   = true
}

variable "jwt_secret_key" {
  description = "Secret key JWT"
  type        = string
  sensitive   = true
}