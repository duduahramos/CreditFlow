resource "aws_db_subnet_group" "main" {
  name       = "postgres-dev-sng"
  subnet_ids = [aws_subnet.subnet_a.id, aws_subnet.subnet_b.id]

  tags = {
    Name = "postgres-dev-sng"
  }
}