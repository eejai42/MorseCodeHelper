

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

    
    
    
    
    -- COUNT: 5
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CharacterId' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [CharacterId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 5
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 5
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 5
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Symbol' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [Symbol] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [Symbol] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 5
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'AlphabetId' AND Object_ID = Object_ID(N'Character'))
BEGIN
        ALTER TABLE [dbo].[Character] ADD [AlphabetId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Character] ALTER COLUMN [AlphabetId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 5
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Communication'))
BEGIN
        ALTER TABLE [dbo].[Communication] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 5
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Communication'))
BEGIN
        ALTER TABLE [dbo].[Communication] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Communication] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 5
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Communication'))
BEGIN
        ALTER TABLE [dbo].[Communication] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Communication] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 5
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TelegraphStationId' AND Object_ID = Object_ID(N'Communication'))
BEGIN
        ALTER TABLE [dbo].[Communication] ADD [TelegraphStationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Communication] ALTER COLUMN [TelegraphStationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 5
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'AlphabetId' AND Object_ID = Object_ID(N'Communication'))
BEGIN
        ALTER TABLE [dbo].[Communication] ADD [AlphabetId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Communication] ALTER COLUMN [AlphabetId] UNIQUEIDENTIFIER NULL;

    

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
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CharacterId' AND Object_ID = Object_ID(N'Sequence'))
BEGIN
        ALTER TABLE [dbo].[Sequence] ADD [CharacterId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Sequence] ALTER COLUMN [CharacterId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    
    
    -- COUNT: 8
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SignalId' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [SignalId] UNIQUEIDENTIFIER NULL;
END

    
    
    
    
    -- COUNT: 8
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [Name] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [Name] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 8
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Description' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [Description] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [Description] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 8
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Symbol' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [Symbol] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [Symbol] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 8
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ShortCode' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [ShortCode] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [ShortCode] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 8
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LongCode' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [LongCode] NVARCHAR(100) NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [LongCode] NVARCHAR(100) NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 8
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'RelativeTime' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [RelativeTime] INT NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [RelativeTime] INT NOT NULL;

    

	END

    
    
    
    
    -- COUNT: 8
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'SequenceId' AND Object_ID = Object_ID(N'Signal'))
BEGIN
        ALTER TABLE [dbo].[Signal] ADD [SequenceId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Signal] ALTER COLUMN [SequenceId] UNIQUEIDENTIFIER NULL;

    

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
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Sentence'))
BEGIN
        ALTER TABLE [dbo].[Sentence] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Sentence] ALTER COLUMN [CommunicationId] UNIQUEIDENTIFIER NULL;

    

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
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CommunicationId' AND Object_ID = Object_ID(N'Customer'))
BEGIN
        ALTER TABLE [dbo].[Customer] ADD [CommunicationId] UNIQUEIDENTIFIER NULL;
END

    
ELSE
    BEGIN 


        ALTER TABLE [dbo].[Customer] ALTER COLUMN [CommunicationId] UNIQUEIDENTIFIER NULL;

    

	END

    
    
    

SELECT *
FROM (SELECT 'true' AS Success) AS Results
FOR XML AUTO
                   