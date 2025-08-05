resource "aws_sqs_queue" "credit_request_queue" {
  name                      = "creditflow-request-queue"
  delay_seconds             = 90
  max_message_size          = 1024
  message_retention_seconds = 86400
  receive_wait_time_seconds = 10

  tags = {
    Environment = "prod"
  }
}

resource "aws_sqs_queue" "credit_response_queue" {
  name                      = "creditflow-response-queue"
  delay_seconds             = 90
  max_message_size          = 1024
  message_retention_seconds = 86400
  receive_wait_time_seconds = 10

  tags = {
    Environment = "prod"
  }
}