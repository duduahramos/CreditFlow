resource "aws_db_instance" "postgresql" {
  identifier              = "creditflow"
  allocated_storage       = 5
  db_name                 = "creditflow_db"
  engine                  = "postgres"
  engine_version          = "15"
  instance_class          = "db.t3.micro"
  username                = var.db_username
  password                = var.db_password
  skip_final_snapshot     = true
  backup_retention_period = 0
  publicly_accessible     = true

  vpc_security_group_ids = [aws_security_group.dev_rds_sg.id]
  db_subnet_group_name   = aws_db_subnet_group.main.name

  deletion_protection = false
}