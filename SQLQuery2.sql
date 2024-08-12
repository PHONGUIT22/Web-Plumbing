-- Tạo bảng Sảnh
CREATE TABLE Venues (
    VenueID INT PRIMARY KEY,
    Name VARCHAR(255),
    Type CHAR(1),
    MaxTables INT,
    MinPricePerTable DECIMAL(10, 2)
);

-- Tạo bảng Khách hàng
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    GroomName VARCHAR(255),
    BrideName VARCHAR(255),
    Phone VARCHAR(15)
);

-- Tạo bảng Đặt Tiệc Cưới
CREATE TABLE WeddingBookings (
    BookingID INT PRIMARY KEY,
    CustomerID INT,
    VenueID INT,
    EventDate DATE,
    Session VARCHAR(10),
    Deposit DECIMAL(10, 2),
    NumTables INT,
    NumReservedTables INT,
    CHECK (Session IN ('Morning', 'Afternoon')), -- Ràng buộc giá trị cho Session
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (VenueID) REFERENCES Venues(VenueID)
);

-- Tạo bảng Dịch Vụ Đặt Thêm
CREATE TABLE AdditionalServices (
    ServiceID INT PRIMARY KEY,
    Name VARCHAR(255),
    Price DECIMAL(10, 2)
);

-- Tạo bảng Chi Tiết Đặt Dịch Vụ
CREATE TABLE ServiceDetails (
    BookingID INT,
    ServiceID INT,
    Quantity INT,
    FOREIGN KEY (BookingID) REFERENCES WeddingBookings(BookingID),
    FOREIGN KEY (ServiceID) REFERENCES AdditionalServices(ServiceID),
    PRIMARY KEY (BookingID, ServiceID)
);

-- Tạo bảng Hóa Đơn
CREATE TABLE Invoices (
    InvoiceID INT PRIMARY KEY,
    BookingID INT,
    PaymentDate DATE,
    TotalTableCost DECIMAL(10, 2),
    TotalServiceCost DECIMAL(10, 2),
    TotalCost DECIMAL(10, 2),
    RemainingAmount DECIMAL(10, 2),
    FOREIGN KEY (BookingID) REFERENCES WeddingBookings(BookingID)
);

-- Tạo bảng Báo Cáo Doanh Thu
CREATE TABLE RevenueReports (
    ReportID INT PRIMARY KEY,
    Month DATE,
    TotalRevenue DECIMAL(18, 2)
);
