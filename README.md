# GymProgramManager API

- [GPM Program API](#gpm-program-api)
  - [Create Program](#create-program)
    - [Create Program Request](#create-program-request)
    - [Create Program Response](#create-program-response)
  - [Get Program](#get-program)
    - [Get Program Request](#get-program-request)
    - [Get Program Response](#get-program-response)
  - [Update Program](#update-program)
    - [Update Program Request](#update-program-request)
    - [Update Program Response](#update-program-response)
  - [Delete Program](#delete-program)
    - [Delete Program Request](#delete-program-request)
    - [Delete Program Response](#delete-program-response)

## Create Program

### Create Program Request

```js
POST /programs
```

```json
{
    "name": "Chest Hypertrophy",
    "description": "Hypertrophy focused chest workout. Focus on slow & controlled reps with moderate weight!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "exercises": [
        "Smith Machine Incline Press 3x10",
        "Chest Flys 3x10",
        "Chest Press Machine 3x10"
    ]
}
```

### Create Program Response

```js
201 Created
```

```yml
Location: {{host}}/Programs/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Chest Hypertrophy",
    "description": "Hypertrophy focused chest workout. Focus on slow & controlled reps with moderate weight!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "exercises": [
        "Smith Machine Incline Press 3x10",
        "Chest Flys 3x10",
        "Chest Press Machine 3x10"
    ]
}
```

## Get Program

### Get Program Request

```js
GET /programs/{{id}}
```

### Get Program Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Chest Hypertrophy",
    "description": "Hypertrophy focused chest workout. Focus on slow & controlled reps with moderate weight!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "exercises": [
        "Smith Machine Incline Press 3x10",
        "Chest Flys 3x10",
        "Chest Press Machine 3x10"
    ]
}
```

## Update Program

### Update Program Request

```js
PUT /programs/{{id}}
```

```json
{
    "name": "Chest Hypertrophy",
    "description": "Hypertrophy focused chest workout. Focus on slow & controlled reps with moderate weight!",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "exercises": [
        "Smith Machine Incline Press 3x10",
        "Chest Flys 3x10",
        "Chest Press Machine 3x10"
    ]
}
```

### Update Program Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Programs/{{id}}
```

## Delete Program

### Delete Program Request

```js
DELETE /programs/{{id}}
```

### Delete Program Response

```js
204 No Content
```
