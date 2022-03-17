Restaurant program

1. How to set up the program
2. How it works
3. How to use it
4. Known issues

1. How to set up the programe
1.1 Once u pulled everything from GIT, please place Food.csv and Drinks.csv files to your wanted location.
1.2 In restaurant.cs class row 11 place location of the files without file name itself. It should look similar like this
filesDir = @"C:\Users\tadas.valutis\Desktop\CodeAcademy\C# Advanced exam\CSVfiles\";
1.3. File name and its extantion place in Program.cs class row 14 and 15. It should look similar to this:
Food.ReadFromCSV(Models.Restaurant.filesDir + "Food.csv");
Food.ReadFromCSV(Models.Restaurant.filesDir + "Drinks.csv");
1.4. In Order.cs class SendEmail method, provide your email and password for your email. Also write your location from where your receipt 
attachment will be taken. It should look similar like this: attachment = new System.Net.Mail.Attachment(@"C:\Users\tadas.valutis\Desktop\CodeAcademy\C# Advanced exam\CSVfiles\CustomerReceipt.txt");

2. How it works.
This programe assumes that the user is a waiter or waitress at the restaurant who can using this program see status of the table,
if it is booked or not. Can order food for the specific table, can free(release) the booked table. Show the receipt, depending on the customer choise receipt can be either writen 
to the file or ignored. The receipt for the restaurant is allways writen to the file and depending of your choise can be sent to your email.

3. How to use it.
3.1 When program starts user presented with different options
3.2 By presing 1 you can see status of the table. if its taken or not.
3.3 By pressing 2 user will be asked which table you would like to book. Select table, you would like to book.
3.4 Once you selected a table, in menu you can select to order food, press 4. 
3.5 System will ask which table you would like to serve. If you select same table to serve as you booked,
you will be presented with menu of foods. 
3.6 Select a food and select how many items would you like to have. You will be presented with menu as long
as you will not choose to exit by presing 6.
3.7 Once you are back in the main menu you can make a payment and free the table by pressing 3.
You have to select which table would you like to free. 
3.8 Receipt will be printed and you will be asked if you would like to have a receipt written to the file. If you choose Yes[1], receipt for customer will be writen to file. If
you select no [2], receipt will not be writen to file. Receipt for restourant will be printed either way.
You also will be asked to provide your email where receipt will be sent. If you leave blank receipt will not be sent.
3.9 Exit program py pressing 6.

4. Known issues

4.1 You cannot serve table if table was not been booked before.
4.2 You cannot select higher number than the number of food items in the food csv
4.3 You cannot select drink items, I did not mannage to make same receipt from 2 different classes, food and drinks :(
4.4 Email method is not tested enougth with the attachement. It prints in boddy. but not sure about attachements



