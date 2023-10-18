# Для развертывания:
1. Выполнить команды
   ```
   docker build . -t cargo WebService
   docker run -p 5001:80 cargo
   ```
   Чтобы собрать и запустить образ сервиса на порту 5001

2. (Пропустить пункт если все выполняется на одной машине) Прописать в конфиге ```App.config``` проекта Cargo адрес машины, на которой развернут сервер в поле ```CargoWebServiceUrl```
1. Выполнить команду ```msbuild Cargo.csproj /t:publish /p:configuration=release``` чтобы получить exe десктоп приложения в папке Release
