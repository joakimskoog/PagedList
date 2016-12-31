# SimplePagedList
[![Build Status](https://travis-ci.org/joakimskoog/PagedList.svg?branch=master)](https://travis-ci.org/joakimskoog/PagedList) [![NuGet](https://img.shields.io/nuget/v/SimplePagedList.svg)](https://www.nuget.org/packages/SimplePagedList/)
## Installation
````
Install-Package SimplePagedList
```

## What?
SimplePagedList is a [1.0 .NET Standard Library](https://docs.microsoft.com/en-us/dotnet/articles/standard/library) that contains a data structure for easily representing a paged list.

## Why?
I often need pagination of some sort in my different projects and since I couldn't find one that I liked, I decided to implement a library that works on all .NET platforms and that suit my needs perfectly.

## How?
There are two ways to create a PagedList and the one you should choose depends on whether you want full control over how the pagination is done and if the [IQueryable LINQ Provider](https://msdn.microsoft.com/en-us/library/bb546158.aspx) that you use has support for `Skip` and `Take`.

### Alternative 1.
This is the alternative that you should pick if you just want an easy way of paginating a superset, without all the hassle. Note that the IQueryable LINQ Provider also needs to have support for the aforementioned methods `Skip` and `Take`.

```csharp
var pageNumber = 1; //We want to retieve the first page of the superset
var pageSize = 10; //We want to use a pageSize of 10 since that's a nice and even number.
var queryableSuperset = _repository.GetAllAsQueryable(); //Retrieve all items in the database as a queryable

//Create the paged list, after this we're ready to build the next Reddit
var pagedList = new PagedList<Post>(queryableSuperset, pageNumber, pageSize);

//TODO: Implement a sweet UI with the paged list
```

### Alternative 2.
Do you want full control over how the pagination is done or does your IQueryable LINQ Provider not have support for `Skip` and `Take` (thanks DocumentDB)? Then this is the alternative for you, below you will find an example on how you can create an instance of this awesomely cool paged list.

```csharp
var pageNumber = 1; //We want to retieve the first page of the superset
var pageSize = 10; //We want to use a pageSize of 10 since that's a nice and even number.
var queryableSuperset = _repository.GetAllAsQueryable(); //Retrieve all items in the database as a queryable

var paginationData = new PaginationData(queryableSuperset.Count(), pageNumber, pageSize);
var pageItems = queryableSuperset.Skip((paginationData.PageNumber - 1) * paginationData.PageSize).Take(paginationData.PageSize);

//Create the paged list, after this we're ready to build the next imgur
var pagedList = new PagedList<Post>(paginationData, pageItems)

//TODO: Implement a sweet UI with the paged list
```
