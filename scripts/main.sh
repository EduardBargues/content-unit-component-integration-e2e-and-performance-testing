
docker-compose down

docker container stop $(docker ps -a -q)
docker container rm $(docker ps -a -q) 
docker image rmi $(docker images -q)

docker image build . --file dockerfile.api --tag api
docker image build . --file dockerfile.api-dependency --tag api-dependency
docker image build . --file dockerfile.api-service-discovery --tag api-service-discovery
docker image build . --file dockerfile.int-tests --tag int-tests
docker image build . --file dockerfile.e2e-tests --tag e2e-tests

docker-compose up -d
# docker-compose run int-tests npm run int
docker-compose run e2e-tests npm run e2e