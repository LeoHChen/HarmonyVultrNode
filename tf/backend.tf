terraform {
  backend "local" {
    path = "/harmony/data/state/harmony.tfstate"
  }
}