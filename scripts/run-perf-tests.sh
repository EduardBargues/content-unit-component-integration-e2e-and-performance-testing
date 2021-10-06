
docker-compose down

docker container stop $(docker ps -a -q)
docker container rm $(docker ps -a -q) 
docker image rmi $(docker images -q)

docker image build . --file dockerfile.api --tag api
docker image build . --file dockerfile.api-dependency --tag api-dependency
docker image build . --file dockerfile.api-service-discovery --tag api-service-discovery
docker image build . --file dockerfile.tests-int --tag tests-int
docker image build . --file dockerfile.tests-e2e --tag tests-e2e

docker-compose up -d
docker-compose run tests-perf run --vus 10 --duration 10s /scripts/main.js