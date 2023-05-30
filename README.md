# Container-Cat
Цель проекта - dashboard, которая "умеет" работать на ARM и x86_64, с Docker и Podman. 
Пока что реализовано:
1. Превращение полученного на вход списка IP:Port в объект HostAddress и дальнейшее создание списка HostSystems (модель, содержащая данные о хосте: ОС, данные о сети, контейнеры...)
2. Инициализация объекта HostSystem: опрос хоста (на предмет доступности), подключение и работа с Docker Engine API.
3. Обработка ответа: получение данных о контейнерах на хосте (трансформация полученного JSON в List<DockerContainer>) с обработкой очевидных ошибок.
  
В данный момент пока не очень понятно:
1. В какой форме реализовывать persistent storage: MongoDB + PostgreSQL? 
2. Стоит ли добавлять управление контейнерами на удалённых хостах?

В ближайшее время буду добавлять:
1. Вывод хоть каких-то данных на frontend (статус контейнеров у хоста как минимум, список контейнеров, список хостов...) через DTO.
2. Работа с TLS и подключением к Engine API по HTTPS (потому что надо защищать API обязательно).
  
(=ↀωↀ=)
