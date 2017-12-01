
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO
    
    
      -- TABLE: Alphabet
      -- TABLE: Character
      -- TABLE: Communication
      -- TABLE: Controller
      -- TABLE: Country
      -- TABLE: MCDevice
      -- TABLE: Language
      -- TABLE: Light
      -- TABLE: Listener
      -- TABLE: Observer
      -- TABLE: TelegraphOperator
      -- TABLE: Proficiency
      -- TABLE: Repeater
      -- TABLE: Sequence
      -- TABLE: Signal
      -- TABLE: Telegraph
      -- TABLE: Transmission
      -- TABLE: Understanding
      -- TABLE: Word
      -- TABLE: TelegraphStation
      -- TABLE: Sentence
      -- TABLE: Customer
      /*
      -- CREATE DATABASE
      IF NOT EXISTS (SELECT * from sys.databases WHERE name = 'MorseCodeHelper')
      BEGIN
          CREATE DATABASE [MorseCodeHelper];
      END
        GO
        
     USE [MorseCodeHelper];
     */
      
      
        -- TABLE: Alphabet
        -- ****** Object:  Table [dbo].[Alphabet]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Alphabet]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Alphabet] (
          [AlphabetId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CountryId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Alphabet] PRIMARY KEY CLUSTERED
          (
            [AlphabetId] ASC
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
          [Symbol] NVARCHAR(100) NOT NULL,
          [AlphabetId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Character] PRIMARY KEY CLUSTERED
          (
            [CharacterId] ASC
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
          [TelegraphOperatorId] UNIQUEIDENTIFIER NULL,
          [AlphabetId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Communication] PRIMARY KEY CLUSTERED
          (
            [CommunicationId] ASC
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

        -- TABLE: Language
        -- ****** Object:  Table [dbo].[Language]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Language]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Language] (
          [LanguageId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CountryId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED
          (
            [LanguageId] ASC
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

        -- TABLE: Sequence
        -- ****** Object:  Table [dbo].[Sequence]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sequence]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Sequence] (
          [SequenceId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CharacterId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Sequence] PRIMARY KEY CLUSTERED
          (
            [SequenceId] ASC
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
          [SequenceId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Signal] PRIMARY KEY CLUSTERED
          (
            [SignalId] ASC
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

        -- TABLE: TelegraphStation
        -- ****** Object:  Table [dbo].[TelegraphStation]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TelegraphStation]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[TelegraphStation] (
          [TelegraphStationId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_TelegraphStation] PRIMARY KEY CLUSTERED
          (
            [TelegraphStationId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Sentence
        -- ****** Object:  Table [dbo].[Sentence]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sentence]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Sentence] (
          [SentenceId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
          [CommunicationId] UNIQUEIDENTIFIER NULL,
        
        CONSTRAINT [PK_Sentence] PRIMARY KEY CLUSTERED
          (
            [SentenceId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Customer
        -- ****** Object:  Table [dbo].[Customer]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Customer] (
          [CustomerId] UNIQUEIDENTIFIER NOT NULL,
          [Name] NVARCHAR(100) NOT NULL,
          [Description] NVARCHAR(100) NOT NULL,
        
        CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
          (
            [CustomerId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO


              -- ****** KEYS FOR Table [dbo].[Alphabet]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Alphabet_AlphabetId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Alphabet] ADD  CONSTRAINT [DF_Alphabet_AlphabetId]  DEFAULT (newid()) FOR [AlphabetId]
          END
          GO
        
          -- FK for CountryId :: 2 :: Alphabet :: Country
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Alphabet_CountryIdCountry]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alphabet]'))
            ALTER TABLE [dbo].[Alphabet]  WITH CHECK ADD  CONSTRAINT [FK_Alphabet_CountryIdCountry] FOREIGN KEY([CountryId])
            REFERENCES [dbo].[Country] (CountryId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Alphabet_CountryIdCountry]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alphabet]'))
            ALTER TABLE [dbo].[Alphabet] CHECK CONSTRAINT [FK_Alphabet_CountryIdCountry]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Character]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Character_CharacterId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Character] ADD  CONSTRAINT [DF_Character_CharacterId]  DEFAULT (newid()) FOR [CharacterId]
          END
          GO
        
          -- FK for AlphabetId :: 1 :: Character :: Alphabet
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Character_AlphabetIdAlphabet]') AND parent_object_id = OBJECT_ID(N'[dbo].[Character]'))
            ALTER TABLE [dbo].[Character]  WITH CHECK ADD  CONSTRAINT [FK_Character_AlphabetIdAlphabet] FOREIGN KEY([AlphabetId])
            REFERENCES [dbo].[Alphabet] (AlphabetId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Character_AlphabetIdAlphabet]') AND parent_object_id = OBJECT_ID(N'[dbo].[Character]'))
            ALTER TABLE [dbo].[Character] CHECK CONSTRAINT [FK_Character_AlphabetIdAlphabet]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Communication]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Communication_CommunicationId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Communication] ADD  CONSTRAINT [DF_Communication_CommunicationId]  DEFAULT (newid()) FOR [CommunicationId]
          END
          GO
        
          -- FK for TelegraphOperatorId :: 8 :: Communication :: TelegraphOperator
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Communication_TelegraphOperator]') AND parent_object_id = OBJECT_ID(N'[dbo].[Communication]'))
            ALTER TABLE [dbo].[Communication]  WITH CHECK ADD  CONSTRAINT [FK_Communication_TelegraphOperator] FOREIGN KEY([TelegraphOperatorId])
            REFERENCES [dbo].[TelegraphOperator] (TelegraphOperatorId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Communication_TelegraphOperator]') AND parent_object_id = OBJECT_ID(N'[dbo].[Communication]'))
            ALTER TABLE [dbo].[Communication] CHECK CONSTRAINT [FK_Communication_TelegraphOperator]
            GO
          
          -- FK for AlphabetId :: 8 :: Communication :: Alphabet
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Communication_AlphabetIdAlphabet]') AND parent_object_id = OBJECT_ID(N'[dbo].[Communication]'))
            ALTER TABLE [dbo].[Communication]  WITH CHECK ADD  CONSTRAINT [FK_Communication_AlphabetIdAlphabet] FOREIGN KEY([AlphabetId])
            REFERENCES [dbo].[Alphabet] (AlphabetId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Communication_AlphabetIdAlphabet]') AND parent_object_id = OBJECT_ID(N'[dbo].[Communication]'))
            ALTER TABLE [dbo].[Communication] CHECK CONSTRAINT [FK_Communication_AlphabetIdAlphabet]
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
          

              -- ****** KEYS FOR Table [dbo].[Country]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Country_CountryId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_CountryId]  DEFAULT (newid()) FOR [CountryId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[MCDevice]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_MCDevice_MCDeviceId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[MCDevice] ADD  CONSTRAINT [DF_MCDevice_MCDeviceId]  DEFAULT (newid()) FOR [MCDeviceId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Language]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Language_LanguageId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Language] ADD  CONSTRAINT [DF_Language_LanguageId]  DEFAULT (newid()) FOR [LanguageId]
          END
          GO
        
          -- FK for CountryId :: 0 :: Language :: Country
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Language_CountryIdCountry]') AND parent_object_id = OBJECT_ID(N'[dbo].[Language]'))
            ALTER TABLE [dbo].[Language]  WITH CHECK ADD  CONSTRAINT [FK_Language_CountryIdCountry] FOREIGN KEY([CountryId])
            REFERENCES [dbo].[Country] (CountryId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Language_CountryIdCountry]') AND parent_object_id = OBJECT_ID(N'[dbo].[Language]'))
            ALTER TABLE [dbo].[Language] CHECK CONSTRAINT [FK_Language_CountryIdCountry]
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
          

              -- ****** KEYS FOR Table [dbo].[TelegraphOperator]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_TelegraphOperator_TelegraphOperatorId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[TelegraphOperator] ADD  CONSTRAINT [DF_TelegraphOperator_TelegraphOperatorId]  DEFAULT (newid()) FOR [TelegraphOperatorId]
          END
          GO
        
          -- FK for CommunicationId :: 1 :: TelegraphOperator :: Communication
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TelegraphOperator_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[TelegraphOperator]'))
            ALTER TABLE [dbo].[TelegraphOperator]  WITH CHECK ADD  CONSTRAINT [FK_TelegraphOperator_CommunicationIdCommunication] FOREIGN KEY([CommunicationId])
            REFERENCES [dbo].[Communication] (CommunicationId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TelegraphOperator_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[TelegraphOperator]'))
            ALTER TABLE [dbo].[TelegraphOperator] CHECK CONSTRAINT [FK_TelegraphOperator_CommunicationIdCommunication]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Proficiency]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Proficiency_ProficiencyId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Proficiency] ADD  CONSTRAINT [DF_Proficiency_ProficiencyId]  DEFAULT (newid()) FOR [ProficiencyId]
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
          

              -- ****** KEYS FOR Table [dbo].[Sequence]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Sequence_SequenceId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Sequence] ADD  CONSTRAINT [DF_Sequence_SequenceId]  DEFAULT (newid()) FOR [SequenceId]
          END
          GO
        
          -- FK for CharacterId :: 1 :: Sequence :: Character
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sequence_Character]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sequence]'))
            ALTER TABLE [dbo].[Sequence]  WITH CHECK ADD  CONSTRAINT [FK_Sequence_Character] FOREIGN KEY([CharacterId])
            REFERENCES [dbo].[Character] (CharacterId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sequence_Character]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sequence]'))
            ALTER TABLE [dbo].[Sequence] CHECK CONSTRAINT [FK_Sequence_Character]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Signal]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Signal_SignalId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Signal] ADD  CONSTRAINT [DF_Signal_SignalId]  DEFAULT (newid()) FOR [SignalId]
          END
          GO
        
          -- FK for SequenceId :: 0 :: Signal :: Sequence
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Signal_Sequence]') AND parent_object_id = OBJECT_ID(N'[dbo].[Signal]'))
            ALTER TABLE [dbo].[Signal]  WITH CHECK ADD  CONSTRAINT [FK_Signal_Sequence] FOREIGN KEY([SequenceId])
            REFERENCES [dbo].[Sequence] (SequenceId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Signal_Sequence]') AND parent_object_id = OBJECT_ID(N'[dbo].[Signal]'))
            ALTER TABLE [dbo].[Signal] CHECK CONSTRAINT [FK_Signal_Sequence]
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
          

              -- ****** KEYS FOR Table [dbo].[Transmission]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Transmission_TransmissionId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Transmission] ADD  CONSTRAINT [DF_Transmission_TransmissionId]  DEFAULT (newid()) FOR [TransmissionId]
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
          

              -- ****** KEYS FOR Table [dbo].[TelegraphStation]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_TelegraphStation_TelegraphStationId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[TelegraphStation] ADD  CONSTRAINT [DF_TelegraphStation_TelegraphStationId]  DEFAULT (newid()) FOR [TelegraphStationId]
          END
          GO
        

              -- ****** KEYS FOR Table [dbo].[Sentence]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Sentence_SentenceId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Sentence] ADD  CONSTRAINT [DF_Sentence_SentenceId]  DEFAULT (newid()) FOR [SentenceId]
          END
          GO
        
          -- FK for CommunicationId :: 0 :: Sentence :: Communication
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sentence_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sentence]'))
            ALTER TABLE [dbo].[Sentence]  WITH CHECK ADD  CONSTRAINT [FK_Sentence_CommunicationIdCommunication] FOREIGN KEY([CommunicationId])
            REFERENCES [dbo].[Communication] (CommunicationId)
          GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sentence_CommunicationIdCommunication]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sentence]'))
            ALTER TABLE [dbo].[Sentence] CHECK CONSTRAINT [FK_Sentence_CommunicationIdCommunication]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Customer]
          -- Primary Key
          IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Customer_CustomerId]') AND type = 'D')
          BEGIN
            ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CustomerId]  DEFAULT (newid()) FOR [CustomerId]
          END
          GO
        


            SELECT 'Successful' as Value
            FROM (SELECT NULL AS FIELD) as Result
            FOR XML AUTO

          