terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "5.50.0"
    }
  }
}


provider "aws" {
  region = var.aws_region

  default_tags {
    tags = {
      Project     = "CreditFlow"
      Environment = "dev"
      Owner       = "eduardo"
    }
  }
}