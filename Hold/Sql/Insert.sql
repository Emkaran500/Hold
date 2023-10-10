INSERT INTO Restaurants([Name of the restaurant], [Texture path])
VALUES ('Mcdonalds', '\Textures\mcdonalds_texture.png'), ('Kfc', '\Textures\kfc_texture.png')

INSERT INTO Products([ProductName], [Price], [Left in stock], [Texture path], [RestaurantId])
VALUES ('Burger', 3, 1, '\Textures\burger_texture.png', 1), ('Cheeseburger', 5, 1, '\Textures\burger_texture.png', 1), ('Chicken', 9, 1, '\Textures\chicken_texture.png', 2), ('Twister', 2, 1, '\Textures\chicken_texture.png', 2)