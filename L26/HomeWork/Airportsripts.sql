CREATE DATABASE AirportInfo;
USE AirportInfo;
GO

CREATE TABLE DepartureBoard
(
    [FlightNumber] [varchar](6) NOT NULL,
    [DepartureCountry] [varchar](30) NOT NULL,
    [DepartureCity] [varchar](30) NOT NULL,
    [DestinationCountry] [varchar](30) NOT NULL, 
    [DestinationCity] [varchar](30) NOT NULL,
    [DepatruteDateTime] [datetimeoffset] NOT NULL,
    [DestinationDateTime] [datetimeoffset] NOT NULL,
    [TimeInFlight] [time] NOT NULL,
    [Carrier] [varbinary](MAX) NULL,
    [PlaneModel] [varchar](20) NOT NULL
);
GO


INSERT INTO DepartureBoard
    ([FlightNumber], [DepartureCountry], [DepartureCity], [DestinationCountry], [DestinationCity], [DepatruteDateTime], [DestinationDateTime], [TimeInFlight], [Carrier], [PlaneModel])
 VALUES
    ('AA1568','Russia', 'Moscow', 'England', 'London','2019-12-10 20:00:00.0 +3:0','2019-12-11 0:30:0.0 +0:0', '4:30:00', NULL, 'Superjet'),
    ('AB468','Russia', 'Moscow', 'France', 'Paris','2019-12-10 20:30:00.0 +3:0','2019-12-11 0:30:0.0 +0:0', '4:00:00', NULL, 'Superjet');
GO

SELECT * FROM DepartureBoard;
GO

DROP DATABASE AirportInfo;
GO