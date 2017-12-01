

USE [MorseCodeHelper];

DECLARE @ObjectName NVARCHAR(100)

    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'MorseCodeId' AND Object_ID = Object_ID(N'MorseCode'))
BEGIN
        ALTER TABLE [dbo].[MorseCode] ADD [MorseCodeId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'MorseCode'))
BEGIN
        ALTER TABLE [dbo].[MorseCode] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[MorseCode] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'MorseCode'))
BEGIN
        ALTER TABLE [dbo].[MorseCode] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[MorseCode] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DeliveryMethodId' AND Object_ID = Object_ID(N'DeliveryMethod'))
BEGIN
        ALTER TABLE [dbo].[DeliveryMethod] ADD [DeliveryMethodId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'DeliveryMethod'))
BEGIN
        ALTER TABLE [dbo].[DeliveryMethod] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[DeliveryMethod] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'DeliveryMethod'))
BEGIN
        ALTER TABLE [dbo].[DeliveryMethod] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[DeliveryMethod] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'MorseCodeId' AND Object_ID = Object_ID(N'DeliveryMethod'))
BEGIN
        ALTER TABLE [dbo].[DeliveryMethod] ADD [MorseCodeId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[DeliveryMethod] ALTER COLUMN [MorseCodeId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ListenerId' AND Object_ID = Object_ID(N'Listener'))
BEGIN
        ALTER TABLE [dbo].[Listener] ADD [ListenerId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Listener'))
BEGIN
        ALTER TABLE [dbo].[Listener] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Listener] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Listener'))
BEGIN
        ALTER TABLE [dbo].[Listener] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Listener] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Listener'))
BEGIN
        ALTER TABLE [dbo].[Listener] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Listener] ALTER COLUMN [CommunicationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ObserverId' AND Object_ID = Object_ID(N'Observer'))
BEGIN
        ALTER TABLE [dbo].[Observer] ADD [ObserverId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Observer'))
BEGIN
        ALTER TABLE [dbo].[Observer] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Observer] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Observer'))
BEGIN
        ALTER TABLE [dbo].[Observer] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Observer] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Observer'))
BEGIN
        ALTER TABLE [dbo].[Observer] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Observer] ALTER COLUMN [CommunicationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'MCDeviceId' AND Object_ID = Object_ID(N'MCDevice'))
BEGIN
        ALTER TABLE [dbo].[MCDevice] ADD [MCDeviceId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'MCDevice'))
BEGIN
        ALTER TABLE [dbo].[MCDevice] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[MCDevice] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'MCDevice'))
BEGIN
        ALTER TABLE [dbo].[MCDevice] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[MCDevice] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphId' AND Object_ID = Object_ID(N'Telegraph'))
BEGIN
        ALTER TABLE [dbo].[Telegraph] ADD [TelegraphId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Telegraph'))
BEGIN
        ALTER TABLE [dbo].[Telegraph] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Telegraph] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Telegraph'))
BEGIN
        ALTER TABLE [dbo].[Telegraph] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Telegraph] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Telegraph'))
BEGIN
        ALTER TABLE [dbo].[Telegraph] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Telegraph] ALTER COLUMN [CommunicationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'AlphabetId' AND Object_ID = Object_ID(N'Alphabet'))
BEGIN
        ALTER TABLE [dbo].[Alphabet] ADD [AlphabetId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Alphabet'))
BEGIN
        ALTER TABLE [dbo].[Alphabet] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Alphabet] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Alphabet'))
BEGIN
        ALTER TABLE [dbo].[Alphabet] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Alphabet] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'MorseCodeId' AND Object_ID = Object_ID(N'Alphabet'))
BEGIN
        ALTER TABLE [dbo].[Alphabet] ADD [MorseCodeId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Alphabet] ALTER COLUMN [MorseCodeId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'PunctuationId' AND Object_ID = Object_ID(N'Punctuation'))
BEGIN
        ALTER TABLE [dbo].[Punctuation] ADD [PunctuationId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Punctuation'))
BEGIN
        ALTER TABLE [dbo].[Punctuation] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Punctuation] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Punctuation'))
BEGIN
        ALTER TABLE [dbo].[Punctuation] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Punctuation] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CharacterId' AND Object_ID = Object_ID(N'Punctuation'))
BEGIN
        ALTER TABLE [dbo].[Punctuation] ADD [CharacterId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Punctuation] ALTER COLUMN [CharacterId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SymbolId' AND Object_ID = Object_ID(N'Symbol'))
BEGIN
        ALTER TABLE [dbo].[Symbol] ADD [SymbolId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Symbol'))
BEGIN
        ALTER TABLE [dbo].[Symbol] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Symbol] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Symbol'))
BEGIN
        ALTER TABLE [dbo].[Symbol] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Symbol] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CharacterId' AND Object_ID = Object_ID(N'Symbol'))
BEGIN
        ALTER TABLE [dbo].[Symbol] ADD [CharacterId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Symbol] ALTER COLUMN [CharacterId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CharacterId' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [CharacterId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'AlphabetId' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [AlphabetId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [AlphabetId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NumeralId' AND Object_ID = Object_ID(N'Numeral'))
BEGIN
        ALTER TABLE [dbo].[Numeral] ADD [NumeralId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Numeral'))
BEGIN
        ALTER TABLE [dbo].[Numeral] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Numeral] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Numeral'))
BEGIN
        ALTER TABLE [dbo].[Numeral] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Numeral] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CharacterId' AND Object_ID = Object_ID(N'Numeral'))
BEGIN
        ALTER TABLE [dbo].[Numeral] ADD [CharacterId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Numeral] ALTER COLUMN [CharacterId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SequenceId' AND Object_ID = Object_ID(N'Sequence'))
BEGIN
        ALTER TABLE [dbo].[Sequence] ADD [SequenceId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Sequence'))
BEGIN
        ALTER TABLE [dbo].[Sequence] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Sequence] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Sequence'))
BEGIN
        ALTER TABLE [dbo].[Sequence] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Sequence] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Sequence'))
BEGIN
        ALTER TABLE [dbo].[Sequence] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Sequence] ALTER COLUMN [CommunicationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DotId' AND Object_ID = Object_ID(N'Dot'))
BEGIN
        ALTER TABLE [dbo].[Dot] ADD [DotId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Dot'))
BEGIN
        ALTER TABLE [dbo].[Dot] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Dot] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Dot'))
BEGIN
        ALTER TABLE [dbo].[Dot] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Dot] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DurationId' AND Object_ID = Object_ID(N'Duration'))
BEGIN
        ALTER TABLE [dbo].[Duration] ADD [DurationId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Duration'))
BEGIN
        ALTER TABLE [dbo].[Duration] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Duration] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Duration'))
BEGIN
        ALTER TABLE [dbo].[Duration] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Duration] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'UnitId' AND Object_ID = Object_ID(N'Unit'))
BEGIN
        ALTER TABLE [dbo].[Unit] ADD [UnitId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Unit'))
BEGIN
        ALTER TABLE [dbo].[Unit] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Unit] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Unit'))
BEGIN
        ALTER TABLE [dbo].[Unit] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Unit] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'MorseCodeId' AND Object_ID = Object_ID(N'Unit'))
BEGIN
        ALTER TABLE [dbo].[Unit] ADD [MorseCodeId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Unit] ALTER COLUMN [MorseCodeId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TransmissionId' AND Object_ID = Object_ID(N'Transmission'))
BEGIN
        ALTER TABLE [dbo].[Transmission] ADD [TransmissionId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Transmission'))
BEGIN
        ALTER TABLE [dbo].[Transmission] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Transmission] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Transmission'))
BEGIN
        ALTER TABLE [dbo].[Transmission] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Transmission] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommuncatinoId' AND Object_ID = Object_ID(N'Transmission'))
BEGIN
        ALTER TABLE [dbo].[Transmission] ADD [CommuncatinoId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Transmission] ALTER COLUMN [CommuncatinoId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DashId' AND Object_ID = Object_ID(N'Dash'))
BEGIN
        ALTER TABLE [dbo].[Dash] ADD [DashId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Dash'))
BEGIN
        ALTER TABLE [dbo].[Dash] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Dash] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Dash'))
BEGIN
        ALTER TABLE [dbo].[Dash] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Dash] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SilenceId' AND Object_ID = Object_ID(N'Silence'))
BEGIN
        ALTER TABLE [dbo].[Silence] ADD [SilenceId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Silence'))
BEGIN
        ALTER TABLE [dbo].[Silence] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Silence] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Silence'))
BEGIN
        ALTER TABLE [dbo].[Silence] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Silence] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CharacterId' AND Object_ID = Object_ID(N'Silence'))
BEGIN
        ALTER TABLE [dbo].[Silence] ADD [CharacterId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Silence] ALTER COLUMN [CharacterId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'WordId' AND Object_ID = Object_ID(N'Word'))
BEGIN
        ALTER TABLE [dbo].[Word] ADD [WordId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Word'))
BEGIN
        ALTER TABLE [dbo].[Word] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Word] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Word'))
BEGIN
        ALTER TABLE [dbo].[Word] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Word] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Word'))
BEGIN
        ALTER TABLE [dbo].[Word] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Word] ALTER COLUMN [CommunicationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SpaceId' AND Object_ID = Object_ID(N'Space'))
BEGIN
        ALTER TABLE [dbo].[Space] ADD [SpaceId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Space'))
BEGIN
        ALTER TABLE [dbo].[Space] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Space] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Space'))
BEGIN
        ALTER TABLE [dbo].[Space] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Space] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CharacterId' AND Object_ID = Object_ID(N'Space'))
BEGIN
        ALTER TABLE [dbo].[Space] ADD [CharacterId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Space] ALTER COLUMN [CharacterId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Communication'))
BEGIN
        ALTER TABLE [dbo].[Communication] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Communication'))
BEGIN
        ALTER TABLE [dbo].[Communication] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Communication] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Communication'))
BEGIN
        ALTER TABLE [dbo].[Communication] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Communication] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'FrequencyId' AND Object_ID = Object_ID(N'Frequency'))
BEGIN
        ALTER TABLE [dbo].[Frequency] ADD [FrequencyId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Frequency'))
BEGIN
        ALTER TABLE [dbo].[Frequency] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Frequency] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Frequency'))
BEGIN
        ALTER TABLE [dbo].[Frequency] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Frequency] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ProficiencyId' AND Object_ID = Object_ID(N'Proficiency'))
BEGIN
        ALTER TABLE [dbo].[Proficiency] ADD [ProficiencyId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Proficiency'))
BEGIN
        ALTER TABLE [dbo].[Proficiency] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Proficiency] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Proficiency'))
BEGIN
        ALTER TABLE [dbo].[Proficiency] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Proficiency] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'OperatorId' AND Object_ID = Object_ID(N'Proficiency'))
BEGIN
        ALTER TABLE [dbo].[Proficiency] ADD [OperatorId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Proficiency] ALTER COLUMN [OperatorId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'UnderstandingId' AND Object_ID = Object_ID(N'Understanding'))
BEGIN
        ALTER TABLE [dbo].[Understanding] ADD [UnderstandingId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Understanding'))
BEGIN
        ALTER TABLE [dbo].[Understanding] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Understanding] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Understanding'))
BEGIN
        ALTER TABLE [dbo].[Understanding] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Understanding] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Understanding'))
BEGIN
        ALTER TABLE [dbo].[Understanding] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Understanding] ALTER COLUMN [CommunicationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SignalId' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [SignalId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'MCDeviceId' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [MCDeviceId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [MCDeviceId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DecodingId' AND Object_ID = Object_ID(N'Decoding'))
BEGIN
        ALTER TABLE [dbo].[Decoding] ADD [DecodingId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Decoding'))
BEGIN
        ALTER TABLE [dbo].[Decoding] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Decoding] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Decoding'))
BEGIN
        ALTER TABLE [dbo].[Decoding] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Decoding] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DeviceId' AND Object_ID = Object_ID(N'Device'))
BEGIN
        ALTER TABLE [dbo].[Device] ADD [DeviceId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Device'))
BEGIN
        ALTER TABLE [dbo].[Device] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Device] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Device'))
BEGIN
        ALTER TABLE [dbo].[Device] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Device] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'AlternativeId' AND Object_ID = Object_ID(N'Alternative'))
BEGIN
        ALTER TABLE [dbo].[Alternative] ADD [AlternativeId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Alternative'))
BEGIN
        ALTER TABLE [dbo].[Alternative] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Alternative] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Alternative'))
BEGIN
        ALTER TABLE [dbo].[Alternative] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Alternative] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ToneId' AND Object_ID = Object_ID(N'Tone'))
BEGIN
        ALTER TABLE [dbo].[Tone] ADD [ToneId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Tone'))
BEGIN
        ALTER TABLE [dbo].[Tone] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Tone] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Tone'))
BEGIN
        ALTER TABLE [dbo].[Tone] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Tone] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Tone'))
BEGIN
        ALTER TABLE [dbo].[Tone] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Tone] ALTER COLUMN [CommunicationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LightId' AND Object_ID = Object_ID(N'Light'))
BEGIN
        ALTER TABLE [dbo].[Light] ADD [LightId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Light'))
BEGIN
        ALTER TABLE [dbo].[Light] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Light] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Light'))
BEGIN
        ALTER TABLE [dbo].[Light] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Light] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'MCDeviceId' AND Object_ID = Object_ID(N'Light'))
BEGIN
        ALTER TABLE [dbo].[Light] ADD [MCDeviceId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Light] ALTER COLUMN [MCDeviceId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ClickId' AND Object_ID = Object_ID(N'Click'))
BEGIN
        ALTER TABLE [dbo].[Click] ADD [ClickId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Click'))
BEGIN
        ALTER TABLE [dbo].[Click] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Click] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Click'))
BEGIN
        ALTER TABLE [dbo].[Click] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Click] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LanguageId' AND Object_ID = Object_ID(N'Language'))
BEGIN
        ALTER TABLE [dbo].[Language] ADD [LanguageId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Language'))
BEGIN
        ALTER TABLE [dbo].[Language] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Language] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Language'))
BEGIN
        ALTER TABLE [dbo].[Language] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Language] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ExtensionId' AND Object_ID = Object_ID(N'Extension'))
BEGIN
        ALTER TABLE [dbo].[Extension] ADD [ExtensionId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Extension'))
BEGIN
        ALTER TABLE [dbo].[Extension] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Extension] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Extension'))
BEGIN
        ALTER TABLE [dbo].[Extension] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Extension] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphOperatorId' AND Object_ID = Object_ID(N'TelegraphOperator'))
BEGIN
        ALTER TABLE [dbo].[TelegraphOperator] ADD [TelegraphOperatorId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'TelegraphOperator'))
BEGIN
        ALTER TABLE [dbo].[TelegraphOperator] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[TelegraphOperator] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'TelegraphOperator'))
BEGIN
        ALTER TABLE [dbo].[TelegraphOperator] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[TelegraphOperator] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'TelegraphOperator'))
BEGIN
        ALTER TABLE [dbo].[TelegraphOperator] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[TelegraphOperator] ALTER COLUMN [CommunicationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CountryId' AND Object_ID = Object_ID(N'Country'))
BEGIN
        ALTER TABLE [dbo].[Country] ADD [CountryId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Country'))
BEGIN
        ALTER TABLE [dbo].[Country] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Country] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Country'))
BEGIN
        ALTER TABLE [dbo].[Country] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Country] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ControllerId' AND Object_ID = Object_ID(N'Controller'))
BEGIN
        ALTER TABLE [dbo].[Controller] ADD [ControllerId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Controller'))
BEGIN
        ALTER TABLE [dbo].[Controller] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Controller] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Controller'))
BEGIN
        ALTER TABLE [dbo].[Controller] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Controller] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Controller'))
BEGIN
        ALTER TABLE [dbo].[Controller] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Controller] ALTER COLUMN [CommunicationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'HumanId' AND Object_ID = Object_ID(N'Human'))
BEGIN
        ALTER TABLE [dbo].[Human] ADD [HumanId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Human'))
BEGIN
        ALTER TABLE [dbo].[Human] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Human] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Human'))
BEGIN
        ALTER TABLE [dbo].[Human] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Human] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DatumId' AND Object_ID = Object_ID(N'Datum'))
BEGIN
        ALTER TABLE [dbo].[Datum] ADD [DatumId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Datum'))
BEGIN
        ALTER TABLE [dbo].[Datum] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Datum] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Datum'))
BEGIN
        ALTER TABLE [dbo].[Datum] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Datum] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ChannelId' AND Object_ID = Object_ID(N'Channel'))
BEGIN
        ALTER TABLE [dbo].[Channel] ADD [ChannelId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Channel'))
BEGIN
        ALTER TABLE [dbo].[Channel] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Channel] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Channel'))
BEGIN
        ALTER TABLE [dbo].[Channel] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Channel] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'RepeaterId' AND Object_ID = Object_ID(N'Repeater'))
BEGIN
        ALTER TABLE [dbo].[Repeater] ADD [RepeaterId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Repeater'))
BEGIN
        ALTER TABLE [dbo].[Repeater] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Repeater] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Repeater'))
BEGIN
        ALTER TABLE [dbo].[Repeater] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Repeater] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'MCDeviceId' AND Object_ID = Object_ID(N'Repeater'))
BEGIN
        ALTER TABLE [dbo].[Repeater] ADD [MCDeviceId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Repeater] ALTER COLUMN [MCDeviceId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    

SELECT *
FROM (SELECT 'true' AS Success) AS Results
FOR XML AUTO
                   