build:
	dotnet lambda package --c Release --output-package dist.zip

deploy: build
	serverless deploy

deploy-web: build
	serverless deploy function -f web