ReadMe.txt

Agri-Energy Connect Platform

                           Overview

Agri-Energy Connect is a comprehensive web platform designed to bridge sustainable agriculture with green energy solutions in South Africa. This prototype demonstrates a functional model of the intended final product, showcasing the integration between farmers and green energy technology providers.

Features

For Farmers
- **Product Management**: Add, edit, and view their own products
- **Dashboard**: Overview of farm profile and product listings
- **Secure Access**: Role-based authentication for data protection

### For Employees
- **Farmer Management**: Add and manage farmer profiles
- **Product Oversight**: View and filter all products from all farmers
- **Advanced Filtering**: Search by category, date range, and farmer
- **Comprehensive Dashboard**: Statistics and quick actions

## Technology Stack

- **Framework**: ASP.NET Core 9.0 MVC
- **Database**: SQL Server LocalDB with Entity Framework Core
- **Authentication**: Session-based authentication with role management
- **UI**: Bootstrap 5 with responsive design
- **Language**: C# with Razor views

## Prerequisites

Before running this application, ensure you have the following installed:

1. **Visual Studio 2022** (Community, Professional, or Enterprise)
2. **.NET 9.0 SDK**
3. **SQL Server LocalDB** (usually included with Visual Studio)

## Installation and Setup

### Step 1: Clone or Download the Project
1. Download the project files to your local machine
2. Extract the ZIP file to a desired location

### Step 2: Open the Project
1. Open Visual Studio 2022
2. Select "Open a project or solution"
3. Navigate to the project folder and select `AgriEnergyConnect.csproj`

### Step 3: Restore NuGet Packages
1. Right-click on the solution in Solution Explorer
2. Select "Restore NuGet Packages"
3. Wait for the restoration to complete

---- Step 4: Build the Project -----
1. Press `Ctrl + Shift + B` or go to Build → Build Solution
2. Ensure the build completes successfully without errors

Step 5: Run the Application
1. Press `F5` or click the "Start" button in Visual Studio
2. The application will open in your default web browser
3. The database will be automatically created on first run

Database Setup

The application uses Entity Framework Core with SQL Server LocalDB. The database is automatically created when you first run the application, and sample data is seeded for demonstration purposes.

Sample Data Included:
- **3 Farmers** with different farm types (Maize, Wheat, Vineyards)
- **5 Products** across various categories (Grains, Fruits)
- **4 Users** (3 farmers + 1 employee) for testing

## User Guide: How to Use the Application

**Simple Overview: How It Works**

Think of this app like a **digital farm office** where farmers and employees can manage agricultural products and connect with each other.

**The Main Areas:**
- **Reception (Home Page)**: Where everyone starts
- **Security Desk (Login)**: Where you prove who you are
- **Farmer Office**: Where farmers manage their products
- **Management Office**: Where employees oversee everything

---

**For Farmers: Your Digital Farm Office**

   Step 1: Logging In as a Farmer**
1. Go to the website homepage
2. Click the **"Farmer Login"** button
3. Enter your credentials:
   - **Username**: `farmer1` (or `farmer2`, `farmer3`)
   - **Password**: `password123`
4. Click **"Login"**
5. You'll be taken to your personal dashboard

### **Step 2: Understanding Your Dashboard**
Your dashboard is like your **personal office** where you can see:
- **Your Profile**: Name, farm location, what you grow
- **Your Products**: A list of everything you're selling
- **Quick Actions**: Easy buttons to add new products

**Example**: Noble Mashao(maize farmer) sees:
- Farm: Mpumalanga
- Farm Type: Maize
- Products: Yellow Maize, White Maize
- Quick button: "Add New Product"

### **Step 3: Adding a New Product**

1. Click the **"Add New Product"** button
2. Fill out the form:
   - **Product Name**: What you're selling (e.g., "Sweet Corn")
   - **Category**: Type of product (e.g., "Vegetables")
   - **Production Date**: When it was produced
   - **Quantity**: How much you have (e.g., "100")
   - **Unit**: Measurement (e.g., "kg")
   - **Price**: Cost per unit (e.g., "R50")
   - **Description**: Any additional details
3. Click **"Add Product"**
4. Your new product appears in your list!

### **Step 4: Managing Your Products**
- **View All Products**: Click "My Products" to see everything
- **Edit Products**: Click "Edit" next to any product to change details
- **See Status**: Products show as "Available" or "Unavailable"

---

**For Employees: The Management Office**

### **Step 1: Logging In as an Employee**
1. Go to the website homepage
2. Click the **"Employee Login"** button
3. Enter your credentials:
   - **Username**: `employee1`
   - **Password**: `password123`
4. Click **"Login"**
5. You'll see the employee dashboard

### **Step 2: Understanding the Employee Dashboard**
Your dashboard is like a **control room** where you can see:
- **All Farmers**: List of everyone registered
- **Statistics**: Numbers like total farmers and products
- **Quick Actions**: Buttons to manage everything

**Example**: Employee sees:
- Total Farmers: 3
- Total Products: 5
- Active Farmers: 3
- Available Products: 5

### **Step 3: Adding a New Farmer**

1. Click **"Add New Farmer"**
2. Fill out the form:
   - **Name**: Farmer's full name
   - **Email**: Contact email
   - **Phone Number**: Contact phone
   - **Farm Location**: Where the farm is
   - **Farm Type**: What they grow (e.g., "Dairy", "Vegetables")
   - **Description**: Any additional notes
3. Click **"Create"**
4. New farmer appears in the system!

### **Step 4: Managing Farmers**
- **View All Farmers**: Click "Manage Farmers" to see everyone
- **Edit Farmer Info**: Click "Edit" to update details
- **View Farmer Details**: Click "View" to see full profile

### **Step 5: Viewing All Products**
1. Click **"View All Products"**
2. You'll see a list of all products from all farmers
3. Use the **filter options** at the top:
   - **Category**: Filter by product type (Grains, Vegetables, etc.)
   - **Farmer**: Filter by specific farmer
   - **Date Range**: Filter by production date
   - **Clear Filters**: Remove all filters

---

**The Smart Filtering System**

### **How to Use Filters (Employees Only)**
Think of filters like a **smart filing cabinet**:

1. **Filter by Category**:
   - Select "Grains" → Only maize, wheat, barley appear
   - Select "Vegetables" → Only vegetables appear

2. **Filter by Farmer**:
   - Select "John Smith" → Only John's products appear
   - Select "All Farmers" → All products appear

3. **Filter by Date**:
   - Set start date → Only products from that date forward
   - Set end date → Only products up to that date

4. **Combine Filters**:
   - You can use multiple filters at once
   - Example: "Grains" + "John Smith" + "Last week"

---

**Security Features**

### **How the App Keeps Everyone Safe**
1. **Different Access Levels**:
   - Farmers can only see their own products
   - Employees can see everything
   - No one can access other people's private information

2. **Session Timeout**:
   - If you leave the computer for 30 minutes, you get logged out
   - This keeps your information safe

3. **Input Validation**:
   - The app checks that you're entering real information
   - Won't let you enter invalid phone numbers or emails

---

**Using the App on Different Devices**

**On a Computer**
- Full screen with all features visible
- Tables show lots of information at once
- Easy to use with mouse and keyboard

### **On a Phone or Tablet**
- Everything automatically adjusts to fit the screen
- Buttons are big enough to tap with fingers
- Same features, just arranged differently
- Works great on any device!

---

**Quick Start Guide**

### **First Time Setup:**
1. Open Visual Studio 2022
2. Open the AgriEnergyConnect project
3. Press **F5** to run the application
4. Wait for the browser to open
5. You'll see the welcome page

### **Testing as a Farmer:**
1. Click **"Farmer Login"**
2. Username: `farmer1`, Password: `password123`
3. Click **"Login"**
4. Explore your dashboard
5. Try adding a new product

### **Testing as an Employee:**
1. Click **"Employee Login"**
2. Username: `employee1`, Password: `password123`
3. Click **"Login"**
4. Explore the employee dashboard
5. Try adding a new farmer
6. Try filtering products

---

**Demo Credentials Summary**

### **Farmer Accounts:**
- **farmer1** / password123 → John Smith (Maize farmer)
- **farmer2** / password123 → Sarah Johnson (Wheat farmer)  
- **farmer3** / password123 → Michael Brown (Vineyard farmer)

### **Employee Account:**
- **employee1** / password123 → System Employee (full access)

---

## **Tips for Best Experience**

1. **Start with the Demo**: Use the provided credentials to explore
2. **Try All Features**: Test adding products, filtering, editing
3. **Use Different Devices**: Try on phone, tablet, and computer
4. **Explore Navigation**: Click all the buttons to see what they do
5. **Check Responsive Design**: Resize your browser window to see how it adapts

---

**Troubleshooting**

### **Common Issues:**

**Can't Log In:**
- Double-check username and password
- Make sure you're using the exact credentials from the demo list

**Page Looks Wrong:**
- Try refreshing the browser (F5)
- Check if you're using a modern browser (Chrome, Firefox, Edge)

**Nothing Happens When Clicking:**
- Make sure the application is running (check Visual Studio)
- Look for any error messages in the browser

**Database Errors:**
- Close the application
- Delete the database file (if it exists)
- Run the application again - it will recreate the database

---



This prototype demonstrates a complete, working system that bridges farmers and agricultural management 

---

**Note**: This is a prototype application for demonstration purposes. 
In a production environment, additional security measures, proper password hashing, and comprehensive error handling would be implemented.


