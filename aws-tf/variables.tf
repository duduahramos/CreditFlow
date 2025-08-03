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