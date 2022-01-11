# Shortenning url service


## Testing

Run te service
```bash
dotnet run
```

create a new short url

```
curl -X POST https://localhost:7259/shorturl -k -d '{"userId":"1", "originalUrl":"https://github.com/olicea", "Url":"shorty"}' -H "Content-Type: application/json" -H "accept: text/plain" 
```


ertrieve a short url
```
curl -X GET https://localhost:7259/shorturl?userId=1\&shortUrl=moZHWo -k
```
