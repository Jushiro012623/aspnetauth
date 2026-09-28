build:
	dotnet build

run:
	dotnet run --project AspAuth

docker:
	docker compose up --build --watch

down:
	docker compose down