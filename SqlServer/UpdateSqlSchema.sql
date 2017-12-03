

USE [MorseCodeHelper];

DECLARE @ObjectName NVARCHAR(100)

    
    
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
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CountryId' AND Object_ID = Object_ID(N'Alphabet'))
BEGIN
        ALTER TABLE [dbo].[Alphabet] ADD [CountryId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Alphabet] ALTER COLUMN [CountryId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CharacterId' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [CharacterId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SequenceCode' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [SequenceCode] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [SequenceCode] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Symbol' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [Symbol] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [Symbol] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'AlphabetId' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [AlphabetId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [AlphabetId] UNIQUEIDENTIFIER NULL;

    

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
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'MCDeviceId' AND Object_ID = Object_ID(N'MCDevice'))
BEGIN
        ALTER TABLE [dbo].[MCDevice] ADD [MCDeviceId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'MCDevice'))
BEGIN
        ALTER TABLE [dbo].[MCDevice] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[MCDevice] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'MCDevice'))
BEGIN
        ALTER TABLE [dbo].[MCDevice] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[MCDevice] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphStationId' AND Object_ID = Object_ID(N'MCDevice'))
BEGIN
        ALTER TABLE [dbo].[MCDevice] ADD [TelegraphStationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[MCDevice] ALTER COLUMN [TelegraphStationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LanguageId' AND Object_ID = Object_ID(N'Language'))
BEGIN
        ALTER TABLE [dbo].[Language] ADD [LanguageId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Language'))
BEGIN
        ALTER TABLE [dbo].[Language] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Language] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Language'))
BEGIN
        ALTER TABLE [dbo].[Language] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Language] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CountryId' AND Object_ID = Object_ID(N'Language'))
BEGIN
        ALTER TABLE [dbo].[Language] ADD [CountryId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Language] ALTER COLUMN [CountryId] UNIQUEIDENTIFIER NULL;

    

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
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphStationId' AND Object_ID = Object_ID(N'TelegraphOperator'))
BEGIN
        ALTER TABLE [dbo].[TelegraphOperator] ADD [TelegraphStationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[TelegraphOperator] ALTER COLUMN [TelegraphStationId] UNIQUEIDENTIFIER NULL;

    

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
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphOperatorId' AND Object_ID = Object_ID(N'Proficiency'))
BEGIN
        ALTER TABLE [dbo].[Proficiency] ADD [TelegraphOperatorId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Proficiency] ALTER COLUMN [TelegraphOperatorId] UNIQUEIDENTIFIER NULL;

    

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

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CharacterSquenceId' AND Object_ID = Object_ID(N'CharacterSquence'))
BEGIN
        ALTER TABLE [dbo].[CharacterSquence] ADD [CharacterSquenceId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'CharacterSquence'))
BEGIN
        ALTER TABLE [dbo].[CharacterSquence] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[CharacterSquence] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'CharacterSquence'))
BEGIN
        ALTER TABLE [dbo].[CharacterSquence] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[CharacterSquence] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SignalIndex' AND Object_ID = Object_ID(N'CharacterSquence'))
BEGIN
        ALTER TABLE [dbo].[CharacterSquence] ADD [SignalIndex] INT NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[CharacterSquence] ALTER COLUMN [SignalIndex] INT NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CharacterId' AND Object_ID = Object_ID(N'CharacterSquence'))
BEGIN
        ALTER TABLE [dbo].[CharacterSquence] ADD [CharacterId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[CharacterSquence] ALTER COLUMN [CharacterId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SignalId' AND Object_ID = Object_ID(N'CharacterSquence'))
BEGIN
        ALTER TABLE [dbo].[CharacterSquence] ADD [SignalId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[CharacterSquence] ALTER COLUMN [SignalId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 9
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SignalId' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [SignalId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 9
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 9
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 9
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Symbol' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [Symbol] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [Symbol] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 9
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ShortCode' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [ShortCode] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [ShortCode] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 9
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LongCode' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [LongCode] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [LongCode] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 9
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'BinaryCode' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [BinaryCode] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [BinaryCode] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 9
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SortOrder' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [SortOrder] INT NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [SortOrder] INT NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 9
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'RelativeTime' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [RelativeTime] INT NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [RelativeTime] INT NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphId' AND Object_ID = Object_ID(N'Telegraph'))
BEGIN
        ALTER TABLE [dbo].[Telegraph] ADD [TelegraphId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Telegraph'))
BEGIN
        ALTER TABLE [dbo].[Telegraph] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Telegraph] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Telegraph'))
BEGIN
        ALTER TABLE [dbo].[Telegraph] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Telegraph] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'InputMessage' AND Object_ID = Object_ID(N'Telegraph'))
BEGIN
        ALTER TABLE [dbo].[Telegraph] ADD [InputMessage] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Telegraph] ALTER COLUMN [InputMessage] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CustomerId' AND Object_ID = Object_ID(N'Telegraph'))
BEGIN
        ALTER TABLE [dbo].[Telegraph] ADD [CustomerId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Telegraph] ALTER COLUMN [CustomerId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 6
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphOperatorId' AND Object_ID = Object_ID(N'Telegraph'))
BEGIN
        ALTER TABLE [dbo].[Telegraph] ADD [TelegraphOperatorId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Telegraph] ALTER COLUMN [TelegraphOperatorId] UNIQUEIDENTIFIER NULL;

    

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
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphId' AND Object_ID = Object_ID(N'Transmission'))
BEGIN
        ALTER TABLE [dbo].[Transmission] ADD [TelegraphId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Transmission] ALTER COLUMN [TelegraphId] UNIQUEIDENTIFIER NULL;

    

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
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SentenceId' AND Object_ID = Object_ID(N'Word'))
BEGIN
        ALTER TABLE [dbo].[Word] ADD [SentenceId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Word] ALTER COLUMN [SentenceId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphStationId' AND Object_ID = Object_ID(N'TelegraphStation'))
BEGIN
        ALTER TABLE [dbo].[TelegraphStation] ADD [TelegraphStationId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'TelegraphStation'))
BEGIN
        ALTER TABLE [dbo].[TelegraphStation] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[TelegraphStation] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 3
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'TelegraphStation'))
BEGIN
        ALTER TABLE [dbo].[TelegraphStation] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[TelegraphStation] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SentenceId' AND Object_ID = Object_ID(N'Sentence'))
BEGIN
        ALTER TABLE [dbo].[Sentence] ADD [SentenceId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Sentence'))
BEGIN
        ALTER TABLE [dbo].[Sentence] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Sentence] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Sentence'))
BEGIN
        ALTER TABLE [dbo].[Sentence] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Sentence] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphId' AND Object_ID = Object_ID(N'Sentence'))
BEGIN
        ALTER TABLE [dbo].[Sentence] ADD [TelegraphId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Sentence] ALTER COLUMN [TelegraphId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CustomerId' AND Object_ID = Object_ID(N'Customer'))
BEGIN
        ALTER TABLE [dbo].[Customer] ADD [CustomerId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Customer'))
BEGIN
        ALTER TABLE [dbo].[Customer] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Customer] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Customer'))
BEGIN
        ALTER TABLE [dbo].[Customer] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Customer] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 4
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphStationId' AND Object_ID = Object_ID(N'Customer'))
BEGIN
        ALTER TABLE [dbo].[Customer] ADD [TelegraphStationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Customer] ALTER COLUMN [TelegraphStationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    

SELECT *
FROM (SELECT 'true' AS Success) AS Results
FOR XML AUTO
                   