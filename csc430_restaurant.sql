/* create schema
CREATE SCHEMA `csc430_restaurant` ;

*/
use csc430_restaurant;

create table stuff 

	(stuff_id 		varchar(15)	not null unique,
	user_name 		varchar(100) not null,
    password		varchar(100) not null,
	primary key(stuff_id));

create table item
   
	(item_id 		varchar(15)	not null unique,
	name 			varchar(100) not null,
	category 		varchar(100) not null,
    price			float not null, 
    inventory		varchar(100) not null,
	primary key(item_id));
    

create table menu
   
	(menu_id 		varchar(15)	not null,
	item_id 		varchar(15)	not null,
    type		varchar(30)	not null,
    last_edited_date 	date not null,
    description 	varchar(100),
	sale_price 		float not null,    
	primary key(menu_id, item_id),
    foreign key(item_id) references item(item_id));
    

create table ipad 

	(ipad_id 	varchar(15)	not null unique,    
	menu_id 	varchar(15) not null, 
    model		varchar(30) not null, 
    table_number	int not null,
	price		float not null,
	date_of_buy		date not null,
	primary key(ipad_id),
    foreign key(menu_id) references menu(menu_id));


create table order_list

	(order_id 		varchar(30)	not null,
    item_id			varchar(15),
    ipad_id			varchar(15),  
	status 			varchar(30),
    description		varchar(100),
	order_time		datetime not null,
    quantity		int,
	primary key(order_id, item_id),
    foreign key(item_id) references item(item_id),
    foreign key(ipad_id) references ipad(ipad_id));


/* populate relations */
insert into item (item_id, name, category, price, inventory) 
values ('ITEM0001', 'Mango green tea', 'tea', 10.00, 50);
insert into item values ('ITEM0002', 'Triple Berry Smoothies', 'smoothie', 10.99, 10);
insert into item values ('ITEM0003', 'Kung Fu Milk Tea', 'tea', 15.99, 9);
insert into item values ('ITEM0004', 'Cappuccino', 'coffee', 5.99, 20);
insert into item values ('ITEM0005', 'Chicken Chow Mein Combo Plate', 'chicken', 15.99, 10);
insert into item values ('ITEM0006', 'Pork Chow Mein Combo Plate', 'pork', 20.99, 10);
insert into item values ('ITEM0007', 'Shrimp with Lobster Sauce Combo Plate', 'seafood', 20.99, 15);
insert into item values ('ITEM0008', 'Honey BBQ Sauce', 'chicken', 6.25, 45);
insert into item values ('ITEM0009', 'Half Fried Chicken', 'chicken', 6.00, 50);
insert into item values ('ITEM0010', 'Fried Chicken Gizzards', 'chicken', 5.75, 50);


insert into menu (menu_id, item_id, type, last_edited_date, description, sale_price) 
values ('M100', 'ITEM0001', 'drink', '2019-12-11', 'Mango green tea', 10.00);
insert into menu values ('M100', 'ITEM0002', 'drink', '2019-12-11', 'Triple Berry Smoothies', 10.99);
insert into menu values ('M100', 'ITEM0003', 'drink', '2019-12-11', 'Kung Fu Milk Tea', 15.99);
insert into menu values ('M100', 'ITEM0004', 'drink', '2019-12-11', 'Cappuccino', 5.99);
insert into menu values ('M101', 'ITEM0005', 'meal', '2019-12-19', 'Chicken Chow Mein Combo Plate', 15.99);
insert into menu values ('M101', 'ITEM0006', 'meal', '2019-12-19', 'Pork Chow Mein Combo Plate', 20.99);
insert into menu values ('M101', 'ITEM0007', 'meal', '2019-12-19', 'Shrimp with Lobster Sauce Combo Plate', 20.99);
insert into menu values ('M102', 'ITEM0008', 'house specialties', '2019-12-16', 'Honey BBQ Sauce', 6.25);
insert into menu values ('M102', 'ITEM0009', 'house specialties', '2019-12-16', 'Half Fried Chicken', 6.00);
insert into menu values ('M102', 'ITEM0010', 'house specialties', '2019-12-16', 'Fried Chicken Gizzards', 5.75);


insert into ipad (ipad_id, menu_id, model, table_number, price, date_of_buy) values ('I001', 'M100', 'MODEL-A',	1, 500, '2019-10-11');
insert into ipad values ('I002', 'M101', 'MODEL-B',	2, 520, '2019-10-11');
insert into ipad values ('I003', 'M102', 'MODEL-C',	3, 550, '2019-10-11');
insert into ipad values ('I004', 'M100', 'MODEL-C',	4, 550, '2019-10-11');
insert into ipad values ('I005', 'M102', 'MODEL-B',	5, 520, '2019-10-11');
insert into ipad values ('I006', 'M102', 'MODEL-A',	6, 500, '2019-10-11');


insert into order_list (order_id, item_id, ipad_id, status, description, order_time, quantity) 
values ('O111111', 'ITEM0001' ,'I001', 'confirmed', 'Mango green tea', '2020-01-01', 2);
insert into order_list values ('O111111', 'ITEM0005' ,'I001', 'confirmed', 'itemChicken Chow Mein Combo Plate', '2020-01-01', 2);
insert into order_list values ('O111112', 'ITEM0003' ,'I003', 'confirmed', 'Kung Fu Milk Tea', '2020-01-15', 3);
insert into order_list values ('O111112', 'ITEM0008' ,'I003', 'confirmed', 'Honey BBQ Sauce', '2020-01-15', 2);
insert into order_list values ('O111112', 'ITEM0001' ,'I003', 'confirmed', 'Mango green tea', '2020-01-15', 3);
insert into order_list values ('O111112', 'ITEM0005' ,'I003', 'confirmed', 'Chicken Chow Mein Combo Plate', '2020-01-15', 1);
insert into order_list values ('O111112', 'ITEM0006' ,'I003', 'confirmed', 'Chicken Chow Mein Combo Plate', '2020-01-15', 2);
insert into order_list values ('O111113', 'ITEM0007' ,'I006', 'confirmed', 'Shrimp with Lobster Sauce Combo Plate', '2020-02-15', 1);
insert into order_list values ('O111113', 'ITEM0001' ,'I006', 'confirmed', 'Mango green tea', '2020-02-15', 1);
insert into order_list values ('O111114', 'ITEM0001' ,'I006', 'paid', 'Mango green tea', '2020-04-15', 1);
insert into order_list values ('O111114', 'ITEM0008' ,'I006', 'paid', 'Honey BBQ Sauce', '2020-04-15', 2);
insert into order_list values ('O111115', 'ITEM0003' ,'I003', 'confirmed', 'Kung Fu Milk Tea', '2020-01-15', 3);

