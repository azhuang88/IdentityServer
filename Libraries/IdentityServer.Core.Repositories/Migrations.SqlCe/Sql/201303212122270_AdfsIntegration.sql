﻿CREATE TABLE [AdfsIntegrationConfiguration] (
    [Id] [int] NOT NULL IDENTITY,
    [Enabled] [bit] NOT NULL,
    [UsernameAuthenticationEnabled] [bit] NOT NULL,
    [SamlAuthenticationEnabled] [bit] NOT NULL,
    [JwtAuthenticationEnabled] [bit] NOT NULL,
    [PassThruAuthenticationToken] [bit] NOT NULL,
    [AuthenticationTokenLifetime] [int] NOT NULL,
    [UserNameAuthenticationEndpoint] [nvarchar](4000),
    [FederationEndpoint] [nvarchar](4000),
    [IssuerUri] [nvarchar](4000),
    [IssuerThumbprint] [nvarchar](4000),
    [EncryptionCertificate] [nvarchar](4000),
    CONSTRAINT [PK_dbo.AdfsIntegrationConfiguration] PRIMARY KEY ([Id])
)
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201303212122270_AdfsIntegration', 0x1F8B0800000000000400ED5D4B73DB3812BE6FD5FE0795EE6339760EBB2979A63C7E24DE1DC729D3999C61129259E143439089FDDBF6B03F69FFC282A42802648378101429976F12D1FCBA01341A8D47B3FFF79FFF2E7F7B0E83D90F9C103F8ECEE6EF8E8EE7331CB9B1E747EBB37996AE7EF9C7FCB75FFFFEB7E595173ECFFEACE84E733AFA6644CEE64F69BAF9B05810F70987881C85BE9BC4245EA5476E1C2E90172F4E8E8FFFB978F76E8129C49C62CD66CBFB2C4AFD10177FE8DF8B3872F126CD50701B7B3820DBE7B4C42950679F5188C906B9F86CFEF0E447DF53ECA659828F6E3C4C81D2170727B40E47F77813133F8D131F9323E7AF603E3B0F7C44657470B09ACF36EF3F7C25D84993385A3B1B94FA287878D9605ABE4201C1DB1A7DD8BC57ADD4F1495EA9058AA238A5707164D428F35D756985AF8AFAE46215953E9B7F0CE24714D0165AF9EB2C29B9302FD057FE8D5FB807F4D19724DEE0247DB9C7AB2DCC8D379F2DF8F716CD1777AF31EFE492D05F517A7A329F7DCE82003D0678D760B4451DDADCF8238E30950D7B5F509AE224CADF2D7BA6C5B5C1C3F1539CFFAA38D1DEA1AA379F5DFBCFD8FB0347EBF469C7ED163D574FDE1F1F530DFC1AF95455E95B69926140BC6ED637846438F99AF8A3F1A6BD9A2237BD0A911F8C20C4255EA12C48BF390FF1771CE5ECC713E2131D301310A310E10F7F8573F324D3FE6E442AA01F66A1454487C41771FCDDC776E0EEF15F999FE0ABC84D5E36A5F52AE17E8FE300A3C814F01E072FB4DBBEA0C200AD7D926ECD564FF8AB2827BE087C6A592EE8737FE5BBD4E69C67E9536E6B5C4B4C5671E2623A4F24E46312679B5B1C3ED2DF4FFEA62F74AEE25FE224EDD76B390AD185592EEA79A573B6F9E65C630F97FDF56AE79C52913C3BFA685BFD72E2BA0FECE07D4A7A57F63C08E29FD4BF0A5E1E626B76A240FBE6A7D4A5BBC728082D013B24B88E13236195070AD5E35BAA7C89FFAA7DB375440D39636BED7B6AE57FD9DC5CCD50A38B72EF9C6F5B8576D0FED93B2F61882937777F42684C1D0F4946D2573B1AACCE1AB79810B4C60E76B3A4E06D0534EFFA7C056D1776708F8B99F2B03704F8250EF0DA004F59F7EB09FB16A7C843297A1B06460D799777FFC95BE3298DCB382294AD1DB07B4CE28C2E7CEE7ED2BA5D535FCF0EEC4DB8097CD74FED215E50FBA68FA6AC80E7DE8AD0FEC7EBB735904A9FE4EBE488FEE2ADB625700785C120C0FFFA990E82FB0511F2F094643C78B103D47BFDD586B4B30B94F7E067A007BD4DECD7C6657F2E6E3D958E27C3403BC3EAAC1F9EB2F071938C52F97A3F9071F926B3CA707C3AA3E07C13ECCD341B35E0A58FD6514CE84027AFBC0559A7BC586D3D24C82DB47790866D2D93C86B6AD26A9A18E168662863A8782E44DCC4E78E4706E3AE3E86EBF5EC9B8AD9E8656EF7F93568578F199639BEF35F970D1B49B92C2D2EC6D2D1DD5AE3C1C289337724B37F9F963BCCD01483FE3CBCDD7BA0299ED3045DA214BD1B91F7C988BC4F2763692BBB4525FDE1535FD5C8D65E1AD8DACB576B6B2F7DB209D0CB589E2A7377C9F08ACF53FCF326FA94780E75F15C1B2720EC8D8EB17754C6DCD6289767B5EAEF9BB383DD048F50EFF244A532319D1AAA36930EB9395136D59BCF39DD858512F7ED58F346633DD660BBC79E9F50BB3DCAD6F1F68AD62AC1E4C9CE99430E68F3046F2BA1E593C60275E063C11CBE6CD357649BF24A8D36114BEB37C66691D22ACE8D6DDF505761DBDFB7CCD7EF4E8AC2DD4566BA1ADA2EEA7B0C922286C1A72AD858D4942139DC11434E8A9F9BD3FBD5963CDD0240012FB35A823298E708A45A7423B3AE300029BEFB2C03A683990080C23BA272418BAB74A08CC0253B195CFB7612802CBBC2246352FA99003074A54706D6B88501A076DED390C1D7878800B2E8845106CA1CAC01A8C26337192C70ACD446878864E23277E2DAD23285129CC676711BAB4920C16B6E8A4090AD8D13B54614B79C1CA09AFF418C9D7300DACD9D85DC952D17655CE3F6C1722108805CDEA2CD86B61D1310B97D3273CA68C88B5F1CFD98C3B0C458B804083DDC49BBE3449D0CB4C68DD2B249AEFD84A4F9A6DA23CA678D0B2F6C9199CF079500E269A1E97AD53D53BD9BFFAE4E11D5E346C1D9A5C1ACEE8B6BDA3C21C52B5A0AEFC45712B9C0715C14A00470002FE2200B239113D9F5761D56C962D44FD59198BB309C38F5635D2C3EEAB10DCA97ABA343E18C2C3A54AE8DDE885304F01B14DA1C1A77BB000E0D0A750E704822CB01A6D0D0BB768822A780ED62756C205E91C5068AB5B1C5A18B002731B13A5FC51BF62C77C5577464E80879E4397710AAF3ABE32059F0FAA91E1281A188086BB96898EDE624B268CD228DA57B7382529ABEB8B5C760F39662F866C154367B69600D3387EDB69ADBDA6F80231F527D4650336AB38DCE96EA2217F19B6DC8E2B13A161FC2C9C2F1250656B31DC809DACB369936AF466C27C0A64131190B506C120C36F2D5E2510B9EB281AF0E3594EF0A879DF29E2C4CA3E36D09834A79974B48A6A1BB7CD428A7B47C91462B419749B826820826331AAA2DAE01A74259386AC14F3E0BAAC01CC204D80A396DA3B648B479B42350012E6DA24373983B235685737F9B549727BB2FD76623DEB52B70C719E8C0E6F360635E2B0CB7602D1BFEDA88D3B00423F5F5F60C60B0FE9546072BF5A912CA34FA516205AB0060C0DA5545BA98C0E97C1B1D20D2E5C35F2B68B3E0CBF55BA6BA0D00354D55369971D33CEE1A6C00A94737177C6523490F6EDA434A12C9CCA24B48357C78718033E7C98BC9D47989639E5956622A754E9D51D02CB34E428D7D8DAED0686E9BA38B504F533E03DD5FDDAD6DAA4A17AD3A57E8162FCB092A1FF39487BDEBDB86644B75C63A189ACC8F7C906432A69EB97A309895578A912E58CA0CBC32D2346CFB487DCADEFC18AC53D5E2B6957A551D6AC86E158767776D9E376927A304B2F06F9BBA20E7A5A0052A20C3F47F7D77139A2A759044938CD9F4C25D9AE737819982C9689C280ADCAAD511F250B1331D2F4F5DB3C0632CCD23AB03D3A7AEC06F9B3AD5CD4741AF6400C3E8565BAF7475CAD652D5866E36A2BA39E3C917E9C8059ECA6A1F2B0BA2B52137BF41B2FFE333611D98306B4E70E6B901DA8900EDC408ED5480763A21ABD4BE0F3C9861EA8EC72E78C94C931C42689C2E1BC6A915D8DDF5767FE3C4454E7393155BA061605AF72375EF4342B1D0DC0805CAD5D1E1B868161FA698C23E481DCBCC22D64F7591AA70C9365A55A28E08C51BB3B850F9ABDB11A8E20D065E011AAFFA0EC76732F5A12543C703878E56DDEC0F1D2E7A98F7A19802ED0B7F6C403070EB8F2DD6C4161FE201C5DA72771E448A6834B9C007858DA2E998953A0A6938CB02473A174CA4C645FCEE30F6A58C60E6C65EF1640C7B606FEF611B61CCF93AE5A37DBA5F4CB83007533FDEF3B868C5D3354976DCB74F76FF77F174DB58367996C156705B49329F558E4BBE4024290E8F72827CE06CE3DBF0D1FB3C376245768B22BA902665C8CED9BC28E372121AE40B5C10E205079034B0706AA59F28D0FD4052235F60F40325EE134A8070FBBEE9006D4343D9FEECF11027F3B3CE03CCD5679D0BF88DF342A72C26E233C113A6E133011326E17BF48DC16409F84CA0B552C198319026DE33816D26DD33E9A356CA3D39C82126DC1BC45E37BE1766AE7A3635AD198FD5178BC9AF670202E5D6EB35FC4579F57A808239F5E47807984F6F20B7A52B959ED2DC6925539E354E60223C6BE81D5FCA35E4716069ECA66D8B05D9EB7A008A32D74DD455E90CEAE90BDCCE5667D1CE4E2E53DD3434FDB012D44DA3CD84238FCF4B670E24FC52A43924F435CB3E35E53F3A6951CFA695876EAA0AA7947ECE04589A7ACE04549676CE045321E59CD192449E6ECE6425AD966CCE9A1B29FEF2B9351666BB867D3E996E8D4167A2B7A1DDECC9E4719B86693BC0F46D03369C2C739BC5F69C42D6B6415AB2F981647BFBF38626C9F4BBF5A6E007914DEDC0BA9EDB4D1CBFD70F38CBD9201D3F4CA75BF05207D21B303599D9291CB7AF6DDDC502F38E951FBF1D7D671490BA9522CC3EF4C970D0A7FBB221E3E7EF3A202B0264E6B26808988B084647FAC2B45B26D6AE2BE5D6E12C0F9B09B32C03F3297AAC818BD35D35F4C220D995F565C79BDBB19FA58050B9BDA19007D26E20BF94356C61FA28E32B0DB636DBBBD34619230EB87B3F62BAA84146389B29CAF604E3F599B88D96BADA599EACA1F6F5535A299C3CDABFA9ED144EEDCC1EBC50BB3BDA5BFA1E199BCA6BD5B41E8FF9E2AB94BF6F6A2799201DB49038BDD24209F23FB56412934222F54D2C256F21880C6E1C2BF9A8640249DF8064B393D14A261A48058963210F964C966E7248284B69B46482092921992C24E092C923268504DA7FEE2E488A21737C81B51E300718C4AF679E30A53461105FC364621DB9C4C4BD27C7AE5389B5E1EB329043EF2C64EDE8A8E5E23E8B72FFA2FC479764FEBA865852CCA8DC2EA9412B9A9B681557DE0BAD1F2B5145D28CD3D85AE9F35CC3919BD2621713529CFBFD89822C5F90878FD8BB89EEB27493A5E784E0F031E03ECBB15C74F32F52ADF1322FEF8A3526B151052AA69FBB6477D1EF991F783BB9AF01974C009177E3D673A7523979E8065EBFEC903EC79122D0B6F92EF10647B98A3F606A5673B3711739E80716CB266F43BEC596B97D4C5048B618F5FBF42F553F2F7CFEF5FF82158B766BA80000, '5.0.0.net45')
