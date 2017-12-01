
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO
    
    
      -- TABLE: MorseCode
      -- TABLE: DeliveryMethod
      -- TABLE: Listener
      -- TABLE: Observer
      -- TABLE: MCDevice
      -- TABLE: Telegraph
      -- TABLE: Alphabet
      -- TABLE: Punctuation
      -- TABLE: Symbol
      -- TABLE: Character
      -- TABLE: Numeral
      -- TABLE: Sequence
      -- TABLE: Dot
      -- TABLE: Duration
      -- TABLE: Unit
      -- TABLE: Transmission
      -- TABLE: Dash
      -- TABLE: Silence
      -- TABLE: Word
      -- TABLE: Space
      -- TABLE: Communication
      -- TABLE: Frequency
      -- TABLE: Proficiency
      -- TABLE: Understanding
      -- TABLE: Signal
      -- TABLE: Decoding
      -- TABLE: Device
      -- TABLE: Alternative
      -- TABLE: Tone
      -- TABLE: Light
      -- TABLE: Click
      -- TABLE: Language
      -- TABLE: Extension
      -- TABLE: TelegraphOperator
      -- TABLE: Country
      -- TABLE: Controller
      -- TABLE: Human
      -- TABLE: Datum
      -- TABLE: Channel
      -- TABLE: Repeater
      /*
      -- CREATE DATABASE
      IF NOT EXISTS (SELECT * from sys.databases WHERE name = 'MorseCodeHelper')
      BEGIN
          CREATE DATABASE [MorseCodeHelper];
      END
        GO
        
     USE [MorseCodeHelper];
     */
      
      
        -- TABLE: MorseCode
        -- ****** Object:  Table [dbo].[MorseCode]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MorseCode]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[MorseCode] (
          [MorseCodeId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_MorseCode] PRIMARY KEY CLUSTERED
          (
            [MorseCodeId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: DeliveryMethod
        -- ****** Object:  Table [dbo].[DeliveryMethod]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryMethod]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[DeliveryMethod] (
          [DeliveryMethodId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [MorseCodeId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_DeliveryMethod] PRIMARY KEY CLUSTERED
          (
            [DeliveryMethodId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Listener
        -- ****** Object:  Table [dbo].[Listener]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Listener]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Listener] (
          [ListenerId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CommunicationId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Listener] PRIMARY KEY CLUSTERED
          (
            [ListenerId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Observer
        -- ****** Object:  Table [dbo].[Observer]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Observer]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Observer] (
          [ObserverId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CommunicationId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Observer] PRIMARY KEY CLUSTERED
          (
            [ObserverId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: MCDevice
        -- ****** Object:  Table [dbo].[MCDevice]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MCDevice]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[MCDevice] (
          [MCDeviceId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_MCDevice] PRIMARY KEY CLUSTERED
          (
            [MCDeviceId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Telegraph
        -- ****** Object:  Table [dbo].[Telegraph]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Telegraph]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Telegraph] (
          [TelegraphId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CommunicationId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Telegraph] PRIMARY KEY CLUSTERED
          (
            [TelegraphId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Alphabet
        -- ****** Object:  Table [dbo].[Alphabet]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Alphabet]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Alphabet] (
          [AlphabetId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [MorseCodeId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Alphabet] PRIMARY KEY CLUSTERED
          (
            [AlphabetId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Punctuation
        -- ****** Object:  Table [dbo].[Punctuation]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Punctuation]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Punctuation] (
          [PunctuationId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CharacterId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Punctuation] PRIMARY KEY CLUSTERED
          (
            [PunctuationId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Symbol
        -- ****** Object:  Table [dbo].[Symbol]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Symbol]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Symbol] (
          [SymbolId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CharacterId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Symbol] PRIMARY KEY CLUSTERED
          (
            [SymbolId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Character
        -- ****** Object:  Table [dbo].[Character]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Character]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Character] (
          [CharacterId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [AlphabetId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Character] PRIMARY KEY CLUSTERED
          (
            [CharacterId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Numeral
        -- ****** Object:  Table [dbo].[Numeral]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Numeral]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Numeral] (
          [NumeralId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CharacterId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Numeral] PRIMARY KEY CLUSTERED
          (
            [NumeralId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Sequence
        -- ****** Object:  Table [dbo].[Sequence]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sequence]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Sequence] (
          [SequenceId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CommunicationId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Sequence] PRIMARY KEY CLUSTERED
          (
            [SequenceId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Dot
        -- ****** Object:  Table [dbo].[Dot]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dot]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Dot] (
          [DotId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Dot] PRIMARY KEY CLUSTERED
          (
            [DotId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Duration
        -- ****** Object:  Table [dbo].[Duration]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Duration]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Duration] (
          [DurationId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Duration] PRIMARY KEY CLUSTERED
          (
            [DurationId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Unit
        -- ****** Object:  Table [dbo].[Unit]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Unit]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Unit] (
          [UnitId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [MorseCodeId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED
          (
            [UnitId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Transmission
        -- ****** Object:  Table [dbo].[Transmission]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transmission]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Transmission] (
          [TransmissionId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CommuncatinoId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Transmission] PRIMARY KEY CLUSTERED
          (
            [TransmissionId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Dash
        -- ****** Object:  Table [dbo].[Dash]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dash]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Dash] (
          [DashId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Dash] PRIMARY KEY CLUSTERED
          (
            [DashId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Silence
        -- ****** Object:  Table [dbo].[Silence]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Silence]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Silence] (
          [SilenceId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CharacterId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Silence] PRIMARY KEY CLUSTERED
          (
            [SilenceId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Word
        -- ****** Object:  Table [dbo].[Word]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Word]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Word] (
          [WordId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CommunicationId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED
          (
            [WordId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Space
        -- ****** Object:  Table [dbo].[Space]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Space]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Space] (
          [SpaceId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CharacterId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Space] PRIMARY KEY CLUSTERED
          (
            [SpaceId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Communication
        -- ****** Object:  Table [dbo].[Communication]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Communication]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Communication] (
          [CommunicationId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Communication] PRIMARY KEY CLUSTERED
          (
            [CommunicationId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Frequency
        -- ****** Object:  Table [dbo].[Frequency]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Frequency]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Frequency] (
          [FrequencyId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Frequency] PRIMARY KEY CLUSTERED
          (
            [FrequencyId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Proficiency
        -- ****** Object:  Table [dbo].[Proficiency]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proficiency]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Proficiency] (
          [ProficiencyId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [OperatorId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Proficiency] PRIMARY KEY CLUSTERED
          (
            [ProficiencyId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Understanding
        -- ****** Object:  Table [dbo].[Understanding]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Understanding]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Understanding] (
          [UnderstandingId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CommunicationId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Understanding] PRIMARY KEY CLUSTERED
          (
            [UnderstandingId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Signal
        -- ****** Object:  Table [dbo].[Signal]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Signal]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Signal] (
          [SignalId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [MCDeviceId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Signal] PRIMARY KEY CLUSTERED
          (
            [SignalId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Decoding
        -- ****** Object:  Table [dbo].[Decoding]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Decoding]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Decoding] (
          [DecodingId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Decoding] PRIMARY KEY CLUSTERED
          (
            [DecodingId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Device
        -- ****** Object:  Table [dbo].[Device]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Device]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Device] (
          [DeviceId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED
          (
            [DeviceId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Alternative
        -- ****** Object:  Table [dbo].[Alternative]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Alternative]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Alternative] (
          [AlternativeId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Alternative] PRIMARY KEY CLUSTERED
          (
            [AlternativeId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Tone
        -- ****** Object:  Table [dbo].[Tone]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tone]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Tone] (
          [ToneId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CommunicationId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Tone] PRIMARY KEY CLUSTERED
          (
            [ToneId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Light
        -- ****** Object:  Table [dbo].[Light]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Light]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Light] (
          [LightId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [MCDeviceId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Light] PRIMARY KEY CLUSTERED
          (
            [LightId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Click
        -- ****** Object:  Table [dbo].[Click]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Click]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Click] (
          [ClickId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Click] PRIMARY KEY CLUSTERED
          (
            [ClickId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Language
        -- ****** Object:  Table [dbo].[Language]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Language]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Language] (
          [LanguageId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED
          (
            [LanguageId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Extension
        -- ****** Object:  Table [dbo].[Extension]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Extension]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Extension] (
          [ExtensionId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Extension] PRIMARY KEY CLUSTERED
          (
            [ExtensionId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: TelegraphOperator
        -- ****** Object:  Table [dbo].[TelegraphOperator]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TelegraphOperator]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[TelegraphOperator] (
          [TelegraphOperatorId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CommunicationId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_TelegraphOperator] PRIMARY KEY CLUSTERED
          (
            [TelegraphOperatorId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Country
        -- ****** Object:  Table [dbo].[Country]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Country]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Country] (
          [CountryId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED
          (
            [CountryId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Controller
        -- ****** Object:  Table [dbo].[Controller]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Controller]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Controller] (
          [ControllerId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CommunicationId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Controller] PRIMARY KEY CLUSTERED
          (
            [ControllerId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Human
        -- ****** Object:  Table [dbo].[Human]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Human]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Human] (
          [HumanId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Human] PRIMARY KEY CLUSTERED
          (
            [HumanId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Datum
        -- ****** Object:  Table [dbo].[Datum]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Datum]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Datum] (
          [DatumId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Datum] PRIMARY KEY CLUSTERED
          (
            [DatumId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Channel
        -- ****** Object:  Table [dbo].[Channel]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Channel]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Channel] (
          [ChannelId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Channel] PRIMARY KEY CLUSTERED
          (
            [ChannelId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Repeater
        -- ****** Object:  Table [dbo].[Repeater]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Repeater]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Repeater] (
          [RepeaterId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [MCDeviceId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Repeater] PRIMARY KEY CLUSTERED
          (
            [RepeaterId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO


              -- ****** KEYS FOR Table [dbo].[MorseCode]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_MorseCode_MorseCodeId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[MorseCode] ADD  CONSTRAINT [DF_MorseCode_MorseCodeId]  DEFAULT (newid()) FOR [MorseCodeId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[DeliveryMethod]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_DeliveryMethod_DeliveryMethodId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[DeliveryMethod] ADD  CONSTRAINT [DF_DeliveryMethod_DeliveryMethodId]  DEFAULT (newid()) FOR [DeliveryMethodId]
          END
          GO
        
          -- FK for MorseCodeId :: 0 :: DeliveryMethod :: MorseCode
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryMethod_MorseCodeIdMorseCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryMethod]'))
            ALTER TABLE [dbo].[DeliveryMethod]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryMethod_MorseCodeIdMorseCode] FOREIGN KEY([MorseCodeId])
            REFERENCES [dbo].[MorseCode] (MorseCodeId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryMethod_MorseCodeIdMorseCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryMethod]'))
            ALTER TABLE [dbo].[DeliveryMethod] CHECK CONSTRAINT [FK_DeliveryMethod_MorseCodeIdMorseCode]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Listener]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Listener_ListenerId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Listener] ADD  CONSTRAINT [DF_Listener_ListenerId]  DEFAULT (newid()) FOR [ListenerId]
          END
          GO
        
          -- FK for CommunicationId :: 0 :: Listener :: Communication
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Listener_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Listener]'))
            ALTER TABLE [dbo].[Listener]  WITH CHECK ADD  CONSTRAINT [FK_Listener_CommunicationIdCommunication] FOREIGN KEY([CommunicationId])
            REFERENCES [dbo].[Communication] (CommunicationId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Listener_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Listener]'))
            ALTER TABLE [dbo].[Listener] CHECK CONSTRAINT [FK_Listener_CommunicationIdCommunication]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Observer]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Observer_ObserverId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Observer] ADD  CONSTRAINT [DF_Observer_ObserverId]  DEFAULT (newid()) FOR [ObserverId]
          END
          GO
        
          -- FK for CommunicationId :: 0 :: Observer :: Communication
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Observer_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Observer]'))
            ALTER TABLE [dbo].[Observer]  WITH CHECK ADD  CONSTRAINT [FK_Observer_CommunicationIdCommunication] FOREIGN KEY([CommunicationId])
            REFERENCES [dbo].[Communication] (CommunicationId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Observer_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Observer]'))
            ALTER TABLE [dbo].[Observer] CHECK CONSTRAINT [FK_Observer_CommunicationIdCommunication]
            GO
          

              -- ****** KEYS FOR Table [dbo].[MCDevice]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_MCDevice_MCDeviceId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[MCDevice] ADD  CONSTRAINT [DF_MCDevice_MCDeviceId]  DEFAULT (newid()) FOR [MCDeviceId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Telegraph]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Telegraph_TelegraphId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Telegraph] ADD  CONSTRAINT [DF_Telegraph_TelegraphId]  DEFAULT (newid()) FOR [TelegraphId]
          END
          GO
        
          -- FK for CommunicationId :: 0 :: Telegraph :: Communication
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Telegraph_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Telegraph]'))
            ALTER TABLE [dbo].[Telegraph]  WITH CHECK ADD  CONSTRAINT [FK_Telegraph_CommunicationIdCommunication] FOREIGN KEY([CommunicationId])
            REFERENCES [dbo].[Communication] (CommunicationId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Telegraph_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Telegraph]'))
            ALTER TABLE [dbo].[Telegraph] CHECK CONSTRAINT [FK_Telegraph_CommunicationIdCommunication]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Alphabet]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Alphabet_AlphabetId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Alphabet] ADD  CONSTRAINT [DF_Alphabet_AlphabetId]  DEFAULT (newid()) FOR [AlphabetId]
          END
          GO
        
          -- FK for MorseCodeId :: 1 :: Alphabet :: MorseCode
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Alphabet_MorseCodeIdMorseCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alphabet]'))
            ALTER TABLE [dbo].[Alphabet]  WITH CHECK ADD  CONSTRAINT [FK_Alphabet_MorseCodeIdMorseCode] FOREIGN KEY([MorseCodeId])
            REFERENCES [dbo].[MorseCode] (MorseCodeId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Alphabet_MorseCodeIdMorseCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alphabet]'))
            ALTER TABLE [dbo].[Alphabet] CHECK CONSTRAINT [FK_Alphabet_MorseCodeIdMorseCode]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Punctuation]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Punctuation_PunctuationId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Punctuation] ADD  CONSTRAINT [DF_Punctuation_PunctuationId]  DEFAULT (newid()) FOR [PunctuationId]
          END
          GO
        
          -- FK for CharacterId :: 0 :: Punctuation :: Character
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Punctuation_CharacterIdCharacter]') AND parent_object_id = OBJECT_ID(N'[dbo].[Punctuation]'))
            ALTER TABLE [dbo].[Punctuation]  WITH CHECK ADD  CONSTRAINT [FK_Punctuation_CharacterIdCharacter] FOREIGN KEY([CharacterId])
            REFERENCES [dbo].[Character] (CharacterId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Punctuation_CharacterIdCharacter]') AND parent_object_id = OBJECT_ID(N'[dbo].[Punctuation]'))
            ALTER TABLE [dbo].[Punctuation] CHECK CONSTRAINT [FK_Punctuation_CharacterIdCharacter]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Symbol]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Symbol_SymbolId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Symbol] ADD  CONSTRAINT [DF_Symbol_SymbolId]  DEFAULT (newid()) FOR [SymbolId]
          END
          GO
        
          -- FK for CharacterId :: 0 :: Symbol :: Character
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Symbol_CharacterIdCharacter]') AND parent_object_id = OBJECT_ID(N'[dbo].[Symbol]'))
            ALTER TABLE [dbo].[Symbol]  WITH CHECK ADD  CONSTRAINT [FK_Symbol_CharacterIdCharacter] FOREIGN KEY([CharacterId])
            REFERENCES [dbo].[Character] (CharacterId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Symbol_CharacterIdCharacter]') AND parent_object_id = OBJECT_ID(N'[dbo].[Symbol]'))
            ALTER TABLE [dbo].[Symbol] CHECK CONSTRAINT [FK_Symbol_CharacterIdCharacter]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Character]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Character_CharacterId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Character] ADD  CONSTRAINT [DF_Character_CharacterId]  DEFAULT (newid()) FOR [CharacterId]
          END
          GO
        
          -- FK for AlphabetId :: 5 :: Character :: Alphabet
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Character_Alphabet]') AND parent_object_id = OBJECT_ID(N'[dbo].[Character]'))
            ALTER TABLE [dbo].[Character]  WITH CHECK ADD  CONSTRAINT [FK_Character_Alphabet] FOREIGN KEY([AlphabetId])
            REFERENCES [dbo].[Alphabet] (AlphabetId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Character_Alphabet]') AND parent_object_id = OBJECT_ID(N'[dbo].[Character]'))
            ALTER TABLE [dbo].[Character] CHECK CONSTRAINT [FK_Character_Alphabet]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Numeral]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Numeral_NumeralId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Numeral] ADD  CONSTRAINT [DF_Numeral_NumeralId]  DEFAULT (newid()) FOR [NumeralId]
          END
          GO
        
          -- FK for CharacterId :: 0 :: Numeral :: Character
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Numeral_CharacterIdCharacter]') AND parent_object_id = OBJECT_ID(N'[dbo].[Numeral]'))
            ALTER TABLE [dbo].[Numeral]  WITH CHECK ADD  CONSTRAINT [FK_Numeral_CharacterIdCharacter] FOREIGN KEY([CharacterId])
            REFERENCES [dbo].[Character] (CharacterId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Numeral_CharacterIdCharacter]') AND parent_object_id = OBJECT_ID(N'[dbo].[Numeral]'))
            ALTER TABLE [dbo].[Numeral] CHECK CONSTRAINT [FK_Numeral_CharacterIdCharacter]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Sequence]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Sequence_SequenceId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Sequence] ADD  CONSTRAINT [DF_Sequence_SequenceId]  DEFAULT (newid()) FOR [SequenceId]
          END
          GO
        
          -- FK for CommunicationId :: 0 :: Sequence :: Communication
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sequence_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sequence]'))
            ALTER TABLE [dbo].[Sequence]  WITH CHECK ADD  CONSTRAINT [FK_Sequence_CommunicationIdCommunication] FOREIGN KEY([CommunicationId])
            REFERENCES [dbo].[Communication] (CommunicationId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sequence_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sequence]'))
            ALTER TABLE [dbo].[Sequence] CHECK CONSTRAINT [FK_Sequence_CommunicationIdCommunication]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Dot]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Dot_DotId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Dot] ADD  CONSTRAINT [DF_Dot_DotId]  DEFAULT (newid()) FOR [DotId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Duration]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Duration_DurationId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Duration] ADD  CONSTRAINT [DF_Duration_DurationId]  DEFAULT (newid()) FOR [DurationId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Unit]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Unit_UnitId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Unit] ADD  CONSTRAINT [DF_Unit_UnitId]  DEFAULT (newid()) FOR [UnitId]
          END
          GO
        
          -- FK for MorseCodeId :: 0 :: Unit :: MorseCode
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Unit_MorseCodeIdMorseCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[Unit]'))
            ALTER TABLE [dbo].[Unit]  WITH CHECK ADD  CONSTRAINT [FK_Unit_MorseCodeIdMorseCode] FOREIGN KEY([MorseCodeId])
            REFERENCES [dbo].[MorseCode] (MorseCodeId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Unit_MorseCodeIdMorseCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[Unit]'))
            ALTER TABLE [dbo].[Unit] CHECK CONSTRAINT [FK_Unit_MorseCodeIdMorseCode]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Transmission]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Transmission_TransmissionId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Transmission] ADD  CONSTRAINT [DF_Transmission_TransmissionId]  DEFAULT (newid()) FOR [TransmissionId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Dash]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Dash_DashId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Dash] ADD  CONSTRAINT [DF_Dash_DashId]  DEFAULT (newid()) FOR [DashId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Silence]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Silence_SilenceId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Silence] ADD  CONSTRAINT [DF_Silence_SilenceId]  DEFAULT (newid()) FOR [SilenceId]
          END
          GO
        
          -- FK for CharacterId :: 0 :: Silence :: Character
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Silence_CharacterIdCharacter]') AND parent_object_id = OBJECT_ID(N'[dbo].[Silence]'))
            ALTER TABLE [dbo].[Silence]  WITH CHECK ADD  CONSTRAINT [FK_Silence_CharacterIdCharacter] FOREIGN KEY([CharacterId])
            REFERENCES [dbo].[Character] (CharacterId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Silence_CharacterIdCharacter]') AND parent_object_id = OBJECT_ID(N'[dbo].[Silence]'))
            ALTER TABLE [dbo].[Silence] CHECK CONSTRAINT [FK_Silence_CharacterIdCharacter]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Word]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Word_WordId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Word] ADD  CONSTRAINT [DF_Word_WordId]  DEFAULT (newid()) FOR [WordId]
          END
          GO
        
          -- FK for CommunicationId :: 0 :: Word :: Communication
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Word_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Word]'))
            ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_CommunicationIdCommunication] FOREIGN KEY([CommunicationId])
            REFERENCES [dbo].[Communication] (CommunicationId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Word_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Word]'))
            ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_CommunicationIdCommunication]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Space]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Space_SpaceId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Space] ADD  CONSTRAINT [DF_Space_SpaceId]  DEFAULT (newid()) FOR [SpaceId]
          END
          GO
        
          -- FK for CharacterId :: 0 :: Space :: Character
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Space_CharacterIdCharacter]') AND parent_object_id = OBJECT_ID(N'[dbo].[Space]'))
            ALTER TABLE [dbo].[Space]  WITH CHECK ADD  CONSTRAINT [FK_Space_CharacterIdCharacter] FOREIGN KEY([CharacterId])
            REFERENCES [dbo].[Character] (CharacterId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Space_CharacterIdCharacter]') AND parent_object_id = OBJECT_ID(N'[dbo].[Space]'))
            ALTER TABLE [dbo].[Space] CHECK CONSTRAINT [FK_Space_CharacterIdCharacter]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Communication]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Communication_CommunicationId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Communication] ADD  CONSTRAINT [DF_Communication_CommunicationId]  DEFAULT (newid()) FOR [CommunicationId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Frequency]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Frequency_FrequencyId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Frequency] ADD  CONSTRAINT [DF_Frequency_FrequencyId]  DEFAULT (newid()) FOR [FrequencyId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Proficiency]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Proficiency_ProficiencyId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Proficiency] ADD  CONSTRAINT [DF_Proficiency_ProficiencyId]  DEFAULT (newid()) FOR [ProficiencyId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Understanding]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Understanding_UnderstandingId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Understanding] ADD  CONSTRAINT [DF_Understanding_UnderstandingId]  DEFAULT (newid()) FOR [UnderstandingId]
          END
          GO
        
          -- FK for CommunicationId :: 0 :: Understanding :: Communication
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Understanding_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Understanding]'))
            ALTER TABLE [dbo].[Understanding]  WITH CHECK ADD  CONSTRAINT [FK_Understanding_CommunicationIdCommunication] FOREIGN KEY([CommunicationId])
            REFERENCES [dbo].[Communication] (CommunicationId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Understanding_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Understanding]'))
            ALTER TABLE [dbo].[Understanding] CHECK CONSTRAINT [FK_Understanding_CommunicationIdCommunication]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Signal]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Signal_SignalId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Signal] ADD  CONSTRAINT [DF_Signal_SignalId]  DEFAULT (newid()) FOR [SignalId]
          END
          GO
        
          -- FK for MCDeviceId :: 0 :: Signal :: MCDevice
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Signal_MCDeviceIdMCDevice]') AND parent_object_id = OBJECT_ID(N'[dbo].[Signal]'))
            ALTER TABLE [dbo].[Signal]  WITH CHECK ADD  CONSTRAINT [FK_Signal_MCDeviceIdMCDevice] FOREIGN KEY([MCDeviceId])
            REFERENCES [dbo].[MCDevice] (MCDeviceId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Signal_MCDeviceIdMCDevice]') AND parent_object_id = OBJECT_ID(N'[dbo].[Signal]'))
            ALTER TABLE [dbo].[Signal] CHECK CONSTRAINT [FK_Signal_MCDeviceIdMCDevice]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Decoding]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Decoding_DecodingId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Decoding] ADD  CONSTRAINT [DF_Decoding_DecodingId]  DEFAULT (newid()) FOR [DecodingId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Device]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Device_DeviceId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_DeviceId]  DEFAULT (newid()) FOR [DeviceId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Alternative]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Alternative_AlternativeId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Alternative] ADD  CONSTRAINT [DF_Alternative_AlternativeId]  DEFAULT (newid()) FOR [AlternativeId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Tone]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Tone_ToneId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Tone] ADD  CONSTRAINT [DF_Tone_ToneId]  DEFAULT (newid()) FOR [ToneId]
          END
          GO
        
          -- FK for CommunicationId :: 0 :: Tone :: Communication
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tone_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tone]'))
            ALTER TABLE [dbo].[Tone]  WITH CHECK ADD  CONSTRAINT [FK_Tone_CommunicationIdCommunication] FOREIGN KEY([CommunicationId])
            REFERENCES [dbo].[Communication] (CommunicationId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tone_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tone]'))
            ALTER TABLE [dbo].[Tone] CHECK CONSTRAINT [FK_Tone_CommunicationIdCommunication]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Light]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Light_LightId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Light] ADD  CONSTRAINT [DF_Light_LightId]  DEFAULT (newid()) FOR [LightId]
          END
          GO
        
          -- FK for MCDeviceId :: 0 :: Light :: MCDevice
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Light_MCDeviceIdMCDevice]') AND parent_object_id = OBJECT_ID(N'[dbo].[Light]'))
            ALTER TABLE [dbo].[Light]  WITH CHECK ADD  CONSTRAINT [FK_Light_MCDeviceIdMCDevice] FOREIGN KEY([MCDeviceId])
            REFERENCES [dbo].[MCDevice] (MCDeviceId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Light_MCDeviceIdMCDevice]') AND parent_object_id = OBJECT_ID(N'[dbo].[Light]'))
            ALTER TABLE [dbo].[Light] CHECK CONSTRAINT [FK_Light_MCDeviceIdMCDevice]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Click]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Click_ClickId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Click] ADD  CONSTRAINT [DF_Click_ClickId]  DEFAULT (newid()) FOR [ClickId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Language]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Language_LanguageId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Language] ADD  CONSTRAINT [DF_Language_LanguageId]  DEFAULT (newid()) FOR [LanguageId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Extension]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Extension_ExtensionId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Extension] ADD  CONSTRAINT [DF_Extension_ExtensionId]  DEFAULT (newid()) FOR [ExtensionId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[TelegraphOperator]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_TelegraphOperator_TelegraphOperatorId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[TelegraphOperator] ADD  CONSTRAINT [DF_TelegraphOperator_TelegraphOperatorId]  DEFAULT (newid()) FOR [TelegraphOperatorId]
          END
          GO
        
          -- FK for CommunicationId :: 0 :: TelegraphOperator :: Communication
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TelegraphOperator_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[TelegraphOperator]'))
            ALTER TABLE [dbo].[TelegraphOperator]  WITH CHECK ADD  CONSTRAINT [FK_TelegraphOperator_CommunicationIdCommunication] FOREIGN KEY([CommunicationId])
            REFERENCES [dbo].[Communication] (CommunicationId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TelegraphOperator_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[TelegraphOperator]'))
            ALTER TABLE [dbo].[TelegraphOperator] CHECK CONSTRAINT [FK_TelegraphOperator_CommunicationIdCommunication]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Country]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Country_CountryId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_CountryId]  DEFAULT (newid()) FOR [CountryId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Controller]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Controller_ControllerId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Controller] ADD  CONSTRAINT [DF_Controller_ControllerId]  DEFAULT (newid()) FOR [ControllerId]
          END
          GO
        
          -- FK for CommunicationId :: 0 :: Controller :: Communication
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Controller_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Controller]'))
            ALTER TABLE [dbo].[Controller]  WITH CHECK ADD  CONSTRAINT [FK_Controller_CommunicationIdCommunication] FOREIGN KEY([CommunicationId])
            REFERENCES [dbo].[Communication] (CommunicationId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Controller_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Controller]'))
            ALTER TABLE [dbo].[Controller] CHECK CONSTRAINT [FK_Controller_CommunicationIdCommunication]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Human]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Human_HumanId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Human] ADD  CONSTRAINT [DF_Human_HumanId]  DEFAULT (newid()) FOR [HumanId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Datum]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Datum_DatumId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Datum] ADD  CONSTRAINT [DF_Datum_DatumId]  DEFAULT (newid()) FOR [DatumId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Channel]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Channel_ChannelId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Channel] ADD  CONSTRAINT [DF_Channel_ChannelId]  DEFAULT (newid()) FOR [ChannelId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Repeater]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Repeater_RepeaterId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Repeater] ADD  CONSTRAINT [DF_Repeater_RepeaterId]  DEFAULT (newid()) FOR [RepeaterId]
          END
          GO
        
          -- FK for MCDeviceId :: 0 :: Repeater :: MCDevice
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Repeater_MCDeviceIdMCDevice]') AND parent_object_id = OBJECT_ID(N'[dbo].[Repeater]'))
            ALTER TABLE [dbo].[Repeater]  WITH CHECK ADD  CONSTRAINT [FK_Repeater_MCDeviceIdMCDevice] FOREIGN KEY([MCDeviceId])
            REFERENCES [dbo].[MCDevice] (MCDeviceId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Repeater_MCDeviceIdMCDevice]') AND parent_object_id = OBJECT_ID(N'[dbo].[Repeater]'))
            ALTER TABLE [dbo].[Repeater] CHECK CONSTRAINT [FK_Repeater_MCDeviceIdMCDevice]
            GO
          


            SELECT 'Successful' as Value
            FROM (SELECT NULL AS FIELD) as Result
            FOR XML AUTO

          