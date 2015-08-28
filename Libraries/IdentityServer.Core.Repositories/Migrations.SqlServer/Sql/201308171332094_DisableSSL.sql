﻿ALTER TABLE [dbo].[GlobalConfiguration] ADD [DisableSSL] [bit] NOT NULL DEFAULT 0
ALTER TABLE [dbo].[GlobalConfiguration] ADD [PublicHostName] [nvarchar](max)
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201308171332094_DisableSSL', 0x1F8B0800000000000400ED5DC972E43612BD4FC4FC43459D661C6195A4F6A1C721D9216BE996A7D5AD50A9DD470755844A1C73291364B734BF3687F9A4F98501B86249100009D622E92691C997892D9158F2D5FFFEF3DFA39F1FA370F215A53848E2E3E9C1DEFE7482E245E207F1F2789A67F7DFBF9DFEFCD35FFF7274EE478F93DF6AB937548E7C19E3E3E94396AD7E9CCDF0E201451EDE8B82459AE0E43EDB5B24D1CCF393D9E1FEFE3F660707334420A6046B3239BAC9E32C8850F10FF9F73489176895E55E7895F828C4D573F2665EA04E3E7A11C22B6F818EA7B70F41FC478616599EA2BD4B1F11A0EC698E525286BD1BB44A7090256980F0DEFCCF703A3909038FD83847E1FD74B2FAE1C7CF18CDB3348997F39597055E78FBB442E4FDBD17625495E8C7D50FA685DA3FA4859A79719C64042E897B55CAB4292E29F079511E6A5651E8E3E9BB30B9F3425243F7C1324F4B2DCC07E4937FA227EE0179749D262B94664F37E8BE82B9F4A79319FFDD4CFCB0F98CF9865A42FE8AB33787D3C9C73C0CBDBB103515466A744EAA1BBD433122B621FFDACB3294C6F4DBB26524AD828E799021FA57AD89B40EE97AD3C945F088FC0F285E660F8DB62BEFB17E42FE9C4E3EC701E9A9E4A32CCD11605DB7E64B8C73947E4E834DA9266D9A798BEC3CF28270FD369CA17B2F0FB32FF3DBE40F1453ED1BB3E13D192C9BB7A2B0E043708FA867D275FC6E44625410E59143C4394E4E93E48F00B981BB417FE6418ACEE345FAB42A1D5709F74B9284C88BFB02DEA0F089B4DAB557F89E6580B3CA630D843F8FA9F0691810A7724A9E07F7C182B89B933C7BA06E66E148C97D922E10992252FC2E4DF2D5158AEEC8DF0FC16A2834EDE1D7499A0D6B358A8287C39C05984ACFE71F8616EB3ABF0B83C5FB0467CE5D78F93FABFE68D6CE8D9D33E697F905F251D9F19EEDBC598E08DFCDC0723D8EA870DB066EF0DEA7830B7B1286C9371223864FB789338757A07D09321296DE202F8C1C01CF717891A4BD8C351E28A41F5F91CE9706CF3ABE5CC6C41B3193C61A5C151463D433EDA62DB9999F5475429A67EDDAE74F518488B2C5DA6CB098366ED31C67CF7624389D31AE10C6DE12CDD1224F0BDD4E4069CBD31D00B7B0A3878DCC7487FC31C0CF5088963DF08CFB7E3B595FA1CCF3BDCC7B1D06BD2AF2136DFEC3D7CA331A97498C895A37603708273959BD7DFA46CA7641E23C37B097D18AAC7082CC1DE229F16FF668C61DF0C4BFC7A4FDD1F275FD63D22674B11F93BF78AFED087CEE45E128C0BF7ECB46C1BDF630BE7D48731EBCD8C61ABCF69221DD6C65D116FC08B4A0BF4A82D6B9AC2DC06D67D28D9930CEC6B6B9E6DB873CBA5BA59B287ABBA1C9847BDBB2C098076432417413EFD52BF70BAE5628BEF449E5C568F1BA4EEB57876781B78C134CFC247EE635C8AE698AC5EA6DEA2D0A07304AC54AAB4CFC9CAAB49E65D77F3A37D26C627832881769C01D908DA5DC7C00B77B01AFFDCB411B739BF6BBDFB506C427CCE16DF0BCBCD7667A96A345D9863AA87C210385F77BCC53BBC8BC59F1DD3AB8BCC01D8AAD7D71C19D26BD801314A0261EB3D43BF332EF6073AA0F37A7FACDB678ECDAFF1143BF0624DAEDE5B3CF7AF8ECB3E7EAB3CF02BC0ABDA70D85BA8CB7ED794DEC21F97619BF4F7DE2ACC91AD9C101147B9966C33B5A1BDC572A17776DB75FB3E2395AA468FDA52E0FB36AE7D2D93BCDE6CF313736CA9A7A8D5AB7756162A4BC1A67FEA6346F68A0DD203F4889BFDEC49E7D7529EE3E45F8C1CD490F0574796E5A59E8F87CB7401DF93096C29775FA8CDC122DD4A626606DF136B0CB64B4685B248E331B8CD6DC83E349BA589F675ED45C8027CB9F6A053FC6914ED1C8A54C9F11D37612DB71D373DE39387CBBB5F38EB57669AF477C89ADE13713C1B00EBD2808D7C9E85BFB92B89F25170B84B1C37B10AC714E9384FA5ED3FAE87D0DCA830A75B4431AE2068585104DB381DA8B750ABFF39F5EA4497493845D6E84FBE2F7791142909224569FDD7AE9928E4E571E8E0DF79ED18ECD5851EC90F9A52892FF2EF59ED7D2B028D0269649856207FB54F9DDBF484F59BFFD4520865FD4C23645B48B590670D0EEF72AE0F3B97A43B1539519EC762DA2D5DE278F18DFC39C955DE28BD05BB644039F631FA5C5692B3B8AF8E295D9A775BF3DB9FA7070309DFCE68539F9775FAA0C49FA70BF913EE896FEF5CB6D237A2897B42C53473981387178791F3CE2B7EBB0D8ACD4D20D1C76C318AE0AA3F241E1E3E002D2ADD5240DFE5DDDD2A64B6AB352D63B2B76453AC13859048532DDCA8B0FB2784BCE637FD22FE25244E3DC926F729587595016EF8954C4DE9EDC73AD2DA883B76E0B38E7C19BF19D58BF4C5DCAB14741EA10C46D73710C25DC953B2A8A1EC5B8E4BC12CFEA1917E0FF98B4FEA72A122825551D8FCC1EED0090EA346A1D3089903000A84C37D51B5A64E6813602397B3A3839D90940D66544E99494672700309421A40313923A00D4CEB40F1D7C7B31194056DD5AD656003BC8A07A505FE6D5413377580160E50D571D2C70835346878474E632D97BB2B5CC4B0D8E703F4BC612053478E2ED010852BA61605689EA9AD303D47BE62046B3A16ED5FDD446754C46F60AF8DD09135DDCB4A31BA5ED5216426757BA22143363751600DC65613EB6DB9F1197D7BD8387A62654CD3A1BACAA8E12BA55F115236E0CF0B50CAC179AD8A07977342B09CEAA0747330513DAD195B75A91A1CD30A3554F26F39216EDF4FBB93DF9585462CC1618E0206BAC6D34911EE62D91F0B61CB117418A337A37EACEA3E1F0A91F4962FD23A1DA00754024B77F3D3AEA6FE9DFF5857273023930AE1294B56D7141AA272278454D21A62B19A14C28DB9D177A29B09F749A847914ABF6A4BABE6EF9D5588CF6A939129356C699D33EB6C5E209D06450FEBD393A446DC6A243EFADD105D232005F90B0D6206CE5031A0409730D304119AB0196B0E877326119D701E5D7E6D8007B198B0DBCB6C6561399019AD4C2E67A0DA92A58ED869FD8D8D04180C66BEE1034D7D7B2A2B1E0ED533B240C43615B2C961E8D1B73CC73733491228D4514DFC9A84733616A1127BA9934D309418938891A4DB1DCCEC06873AB214F5BA15437C35A608D33CF36971BE511DA03473FEC878C723E3B124267DFDA2217446D3264F1D81C8BE76A63E1F8373D3CBBCCD806FA7459CC5A9740E206A81124B6C603145B78A38D7C33E2B942A76EE09B438D155FC3FC727CB40DCBD844844AFA383E2C548A59F45D9E208EEBB4FC2B8B5A829296B82A8204B66634D41BD0234E853AEEB9429F7E163481D9850950E297935125116B1D32DD1CA04516DAB5A09E99D0657A3AE5DC2F8BDAEA64B7B66535EA8DEF027733031D381A1A6DCC5B71EE15AA75C3DF1A713B3CC186DABA3AA11BAD7DB55480466D6A84B21DEDA8F182F53552C0DBD5AF6C3181A410191D10B2D5C367B3C82AF8F7F6355327A1405553BFDB9A71231E468F3680CCA90C0BBDBA916407B7DD434A435BC8A26B442D6278359B2117C9ABC5CC75A9090E59556A298BFDB92ECA436EB3AE4BD0625FA38B0791DBE6E812B4EB291F81E6AF33B9C5AED2256BAE15CA19673541EF377912C5DE149421D9B736631DE422E4473E28B235AE9EB918349A973762452C54EA1CBC31D276F8F64D85BDDCBDACF1A25F43AE46A396B5017BD18DCBDE8C1BAD69CD28248D1AD61C6ACC66553345769D8C88B25BD309744C942EFB825E97412F300119A7FDDB8470280EB241524510FD62078E8483DFE1675E6C4D8F5371523AF53A4A1D267EA6E3E36DEF59E019A5E579E48EF5A72E264A977DAA5B8F41BFD2018CD3B7E47E65DBA75CED43B8E89B8A4B74BD6ECE092C93125EFBCAA68CE0F1BDF5FD03057D24B41E1444D67FCEAA2C0343FCC819CE3CEF8176A8403BEC85F64681F6668B3C9C9C7B319A93EB26892C74E9DC9C1E42E9E8CE0447277117747D3DDCD1717C8EC26DBEF685858391FD94A58B82281AB9110ABC374787E91A597C58621B36CC5A924516B17D6A8B54670FCB68F51B7344880A91C585DE3FBBDD853ADF66E4D564EF15E4EEC45F7DE371CDD0F1C1A1635536F74387CB71E3632865F25B171E40C5045C0F655F5B62AB4F7B81D7D676779E58AB642CB5C027CAC2ABED712B6DC6E7789E0566622C94689D8BFADB71FC4B4907C18DBDE2C926FC81BB7D8C8A03918B75CA47EB0CBF1846430EA67DBC35E302CC755DD3818D9289B1506A775ED389B58B339ACC9AA842B5ED9DC3230BD9EDF79CA7C6995F21D6430E1D12B089352012443EE88024AC333BC0DB6CE2BB6DF6249A4CFDF19C8A92FCB0D0DCC3B374028EB32FD137A4DDD4350E963962B4B656522D1A356CE7D7E384590D89220BD13CB4C491E701E6B14590541323726152FDD032D8C240B405B065A8511C4EC2350B2107543FB4D9E46DE902F94DDEF679BFE94285AC92D97D6FC1F39568678C124C2087711D6C0AF0C3DC3FA58111F7F1AC9867E426B118266A55EA01449BAC31D959692A721BC3D2984C8D9D76127BFCA0601ABCC49446B321491C563B22C18EDCA7259E1D51A41951D593E6FF8667A7E2B8E1C8778A8AA2543A4505E18A6F4724BD2945A6937A0F989EB5E10C457B548076FA9AFFAA16B8F262127FE292C4E3787AB8BFFF763A3909030F97344BF6743EC88F6618FB2140E6C3D0596AC968D6418D5C1C0D6849906DC97D1B569B5249FCD54B170F5EFAB7C87BFCBB359AF433EA2EE0784A1B17B810998D435C81C4C62132C8545FF40B4B3C98AAA63F1EC04DD31F0C20A329C1EE82DE606ABE99FED08679A743147470C6F4876DD962FAB7114313D31F84A587E95F1C91124633DE06FC76A42163CACE4E06C2AFCDF51F132E8780C8AD3214AB2055E90FC253A938F04B3267CA60508121C514CF781C981188ECEC3050718F583B16681E57B28D384017B8461C2076FC72F2380E5647C6B1B39DCA996F95383C0603CA741D5B1D1375126E0C056629369CFB4D2BB28997D3D3CD7F174A47ECF072EA4C39F2F85F1EEB0FA4FCF1D0FE90D00F9C0E2929FF3BA40EFB9939EDC14BEE701A9684FEC01D7408FD41D5C40703569E5DFC060396185D3406FD57DB3AAA0207E1A2FA77EF07C19A6F2B9AA3B1F7AD1D802A6809C60B958D32F75F8E7BEAF9DB92AF556751756699E73B5E71EA6475E7F5A9CBE1DED99A147F337CD8D98785A7363C4B61F205EC01CD878B2281FAB559ABBD4A66B3737D2D3A60CAEDCA5CDED94675D7A00E026A877D423A8015426693A04EC87F1E72A2C96DC53B89348584E7ADD9EC052C66329D5DC21DBA857B33A6EFE84E075EC78F986FB9F7E0928B9D3800F5D837DB8500928AFB7B363885785B57B36D02B133B03A65C401209438DCDBC78FB75C82126C5FC384A1E1B7B2B3FA2ED11CF656E037D607E101C944036F33B8DA975765E20E441C71A35F91A6BAB3A3B4CC79753701F8432650E3E5A2516C5AA6BD3A401A1A173069AF25884FDAAEDC9B1F63875299096AD649D537C3755D55E556A7932BEFF1038A97D9C3F1F4E0F0EDB81ED61A7168F3BA9BE8589FD5C712B78E1E4A121DB2A085524287E0F169A0236FFB7767C1ECEC6ACC26D4300254BAA2DFFB788721A75DAA54C79D9DAA9BA44917EDC4E44D0E58F0D629932E2CAA1327B730C0AF3328AD666F68DFA84D6C1C08A5CA9754C38EBFF0500D4D26A14CEB24D409F326BF365F1B4D13BB3AA8362657799805E50AE6E978BABFB727112A766B03EA49A59213E5F57E272925AD8A52EA1D8A5BD234E12490F351AFD3205E042B2FD4D686F0A555B4479BB3D124BE3943442775636655646287C9BC215BD81822786A5D4572598EF234D2A436328B242E0D51EA9A55EE6CED5C81E4BF493B38AADE024A95098E6408DFD1BDFF72A88182527FE54D50279EC88674C842E674886B8C526601C836A9452193D4D2DA6A02AE8F43350489C19503496AACD0DDF2950DD27E01D9A6FD486326749956360D9482CC0105352674DEB3946DE916878CEAFE42639DEA86956C985212B24929AC6B2FF5C525A0D93A84C1D6EB90D7D8A5BC15245BA516856C524B6B2C02EED5C8B640429015909CAE46981C02B90E989760A995BFF129E911EE23C8BA4401489F28A3D1299D63CA5A651148AF2C65D4AACA96EC6A3D3D76B30F0CC0B7EF400DED6BAB01CC85B09AF1CBC9EA876F457BD7C31E2EBE35318AFBC0D4329EAF44E78599953FE079D9B7A0B7650504553C3786DD6A66C27CAC6BB38E7590E94AA8A9954E2929A4365FF7742BE860DD112946802564138037EF8E66655B550FC8BF12870809FBF3982E7BCBFFCE100E962DC451651E1BF0373297F17D52AF49048B6A1161A95C475027D4CB7B8B8CBCA6DBA5C5B5CFDFBC30A7CBFDE80EF997F1A73C5BE51929328AEE42AECAE9FAA54BFFD14CB2F9E853710C8A5D14819819D09D824FF12F7910FA8DDD17C0A6A90282BAB26A878BB625654840CBA706E963121B0255D5D7ACE76E110979E8D4F9299E7B5F91DA367D1DF23576446384D48B7085D17E4FFE25DDCF8F1E7FFA3F6E0DD2FBB2DB0000, '5.0.0.net45')
