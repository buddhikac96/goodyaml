# YAML-Schema-Validator

This project provide YAML schema validation.

There are two options to provide JSON schema to validate YAML file.
1. By C# class
2. By external JSON file

User can provide both YAML and JSON file by comamnd line arguments.

> Yaml-Schema-Validator.exe -y myyaml -j myjson <br>
> Yaml-Schema-Validator.exe --yaml myyaml --json myjson

**-y / --yaml** Token is required and **-j / --json** token not required. <br>

#### Sample YAML File ####

>Name: your name <br>
>Mobile: your mobile number <br>
>Email: your emial <br>
>University: your univeristy <br>

#### Sample JSON file ####

>{<br>
>   "Name": {"type":"string"},<br>
>   "Email": {"type":"string"},<br>
>   "Mobile": {"type":"string"},<br>
>   "University": {"type":"string"},<br>
>}<br>
