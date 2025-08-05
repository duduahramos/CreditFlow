resource "aws_db_subnet_group" "main" {
  name       = "creditflow-sng"
  subnet_ids = [aws_subnet.subnet_a.id, aws_subnet.subnet_b.id]

  tags = {
    Name = "creditflow-sng"
  }
}