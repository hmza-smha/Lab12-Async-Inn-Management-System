# Async Inn Management System

Bulding a RESTful API hotel server that will increase the managmement of the assets in the hotel.

Increatse the ability to modify and manage rooms, amenities, and new hotel locations built.

## ERD
![image](images/ERD.png)

**Explanation**

The hotel “Async Inn” has different location.

**Hotel**: Represent different location of the hotel, every *Hotel* has multiple *Room*.

**Room**: Represent the rooms inside the hotel, every *Room* has multiple *Amenity*.

**Amenity**: Represent the amenities inside each *Room*.

PK: *The primary key is the column that contain values that uniquely identify each row in a table*

FK: *The foreign key is a field in one table, that refers to the PK in another table. The table with the foreign key is called the child table, and the table with the primary key is called the referenced or parent table.*

## Architecture
### Dependency Injection
- Dependency injection is basically providing the objects that an object needs (its dependencies) instead of having it construct them itself. 

It's a very useful technique for testing, since it allows dependencies to be mocked or stubbed out.

- It is a programming technique *(Design Pattern)* that makes a class independent of its dependencies.

### The advantages/benefits of dependency injection are:
- Increase the usability, testability and maintainability of the system.
- It allows dependencies to be mocked or stubbed out.
- Ability to replace dependencies, without changing the class that uses it.
- Promotes "Code to interface not to an implementation" principle.

In this system we used **Interface** Dependency Injector, by creating a repositories for classes *(Hotel, Room, Amenity)*, and a signutures *(IHotel, IRoom, IAmenity)* for each one of them, to perform CRUD operations.

## Endpoints

### For Hotel
1. GET: api/Hotels
2. GET: api/Hotels/{id}
3. PUT: api/Hotels/{id}
4. POST: api/Hotels/Hotel
5. DELETE: api/Hotels/{id}

### For Room
1. GET: api/Rooms
2. GET: api/Rooms/{id}
3. PUT: api/Rooms/{id}
4. POST: api/Rooms/Room
5. DELETE: api/Rooms/{id}
6. POST: api/Rooms/{roomId}/{amenityId}
7. DELETE: api/Rooms/{roomId}/{amenityId}

### For Hotel Rooms
1. GET: api/HotelRooms/{hotel_id}
2. GET: api/HotelRooms/{hotelId}/{roomNumber}
3. POST: api/HotelRooms/{hotel_id}/{room_id}/{room_number}
4. DELETE: api/HotelRooms/{hotelId}/{roomId}
5. PUT: api/HotelRooms/{hotelId}/{roomNumber}/Room

### For Amenities
1. GET: api/Amenities 
2. GET: api/Amenities/5
3. PUT: api/Amenities/5
4. POST: api/Amenities
5. DELETE: api/Amenities/5

<br>

- GET: Retreve data from the database.
- POST: Indert data into the database.
- PUT: Update data in the database.
- DELETE: Delete data from the databse.