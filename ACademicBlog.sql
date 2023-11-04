USE AcademicBlogDB;
GO

--- Role Table ---
Insert into Role (Id, Name) Values ('662396ee-6231-4d9f-b06e-deac96ec96cf', 'Student');
Insert into Role (Id, Name) Values ('d74b4521-ab22-428e-90d6-591fd0da23b1', 'Lecturer');
Insert into Role (Id, Name) Values ('a9c52b1e-67b1-4834-9b0a-e8bfef9eab1c', 'Admin');

--- Field Table ---
Insert into Field (Id, Name, Status) Values ('e6661e13-4418-45d3-b96e-e69d4d0a5f06', 'Software Engineering ', 'ACTIVE');
Insert into Field (Id, Name, Status) Values ('ca23317f-e026-4e5a-b8aa-e5f80027aced', 'Bussiness', 'ACTIVE');
Insert into Field (Id, Name, Status) Values ('908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc0d', 'Language', 'ACTIVE');

--- Account Table ---
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId,AccountFieldMappingId, Avatar) Values
('50a086dd-9222-4d82-a907-60950b31d9e1', 'Admintrator', 'Admintrator', '@@admin@@', 'ACTIVE', 'admin@AcademicBlog.com', 0, 'a9c52b1e-67b1-4834-9b0a-e8bfef9eab1c', null, 'images/logo.png');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, AccountFieldMappingId, Avatar) Values
('a4cd997e-5976-4cbb-b45d-b5ebded9782f', 'Alex', 'Alexsander', '12345', 'ACTIVE', 'AlexanderWilliams@ACademicBlog.org', 1, '662396ee-6231-4d9f-b06e-deac96ec96cf', null, 'images/alexImage.png');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, AccountFieldMappingId, Avatar) Values
('1e92a1b2-bdcb-4521-bc6f-818b5bd53b98', 'Strange', 'DoctorStrange', '12345', 'ACTIVE', 'DoctorStrange@MCU.marvel', 1, '662396ee-6231-4d9f-b06e-deac96ec96cf', null, 'images/doctorStrangeImage.png');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, Avatar) Values
('f8bb0e19-b646-400e-94ad-8a06f40d3b01', 'Emily', 'EmilyJohnSon', '12345', 'ACTIVE', 'EmilyJohnson@ACademicBlog.org', 1, 'd74b4521-ab22-428e-90d6-591fd0da23b1', 'images/emilyImage.png');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, Avatar) Values
('de317fd1-ed36-40d6-ac74-5aec009da2ca', 'Harly', 'HarlyQuuin', '12345', 'ACTIVE', 'HarlyQuuin@DCU.dc', 1, 'd74b4521-ab22-428e-90d6-591fd0da23b1', 'images/harlyImage.webp');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, Avatar) Values
('c5771dfb-21b3-4061-88a7-a6aae4980af2', 'John', 'JohnWick', '12345', 'ACTIVE', 'JonhWick@JonhWick.jw', 1, 'd74b4521-ab22-428e-90d6-591fd0da23b1', 'images/johnWickImage.webp');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, AccountFieldMappingId, Avatar) Values
('7d696a6f-dd79-4b56-9863-e72d15c3faa6', 'Sophia', 'Sophia Davis', '12345', 'INACTIVE', 'SophiaDavis@ACademicBlog.org', 5, '662396ee-6231-4d9f-b06e-deac96ec96cf', null, 'images/sophiaImage.jpg');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, Avatar) Values
('20b7459c-4bf7-4a89-b91f-107369043d92', 'Benjamin', 'BenjaminThompson', '12345', 'INACTIVE', 'BenjaminThompson@ACademicBlog.org', 5, 'd74b4521-ab22-428e-90d6-591fd0da23b1', 'images/benjaminImage.jpg');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, Avatar) Values
('b365be3d-9559-4e50-8fe9-36a02482087b', 'Manhaten', 'DoctorManhten', '12345', 'INACTIVE', 'DoctorManhaten@DCEU.dc', 5, 'd74b4521-ab22-428e-90d6-591fd0da23b1', 'images/manhattanImage.jpg');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, Avatar) Values
('ca31764c-ab67-4c97-9583-05a0ab9fc9e6', 'Tony', 'TonyStark', '12345', 'INACTIVE', 'TonyStark@MCU.marvel', 5, 'd74b4521-ab22-428e-90d6-591fd0da23b1', 'images/tonyStarkImage.jpg');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, AccountFieldMappingId, Avatar) Values
('673d32dd-c157-4ab1-93e1-1315ea6b136f', 'Charlotte', 'CharlotteEvans', '12345', 'BANNED', 'CharlotteEvans@ACademicBlog.org', 5, '662396ee-6231-4d9f-b06e-deac96ec96cf', null, 'images/challoterImage.webp');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, Avatar) Values
('2167bd65-cc50-4956-aa44-d07d8ec20854', 'Peter', 'PeterParker', '12345', 'BANNED', 'PeterParker@ACademicBlog.org', 5, 'd74b4521-ab22-428e-90d6-591fd0da23b1', 'images/petterImage.jpg');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, Avatar) Values
('6a84948b-a883-4b11-943d-a8a602796d52', 'Peter', 'PeterParker', '12345', 'BANNED', 'PeterParker@MCU.marvel', 5, 'd74b4521-ab22-428e-90d6-591fd0da23b1', 'images/peterMarvelImage.jpg');
Insert into Account (Id, UserName, Name, Password, Status, Gmail, NumberOfBlogs, RoleId, Avatar) Values
('725c507f-60ed-4bca-bbe8-7545dc7b7849', 'Robin', 'TitanRobin', '12345', 'BANNED', 'TintanRobin@DCEU.dc', 5, 'd74b4521-ab22-428e-90d6-591fd0da23b1', 'images/robinImage.jpg');

--- Acount Field Mapping Table ---
Insert into AccountFieldMappings (Id, FieldId, AccountId) Values 
('7e893b0c-7b3b-4d7b-96cf-322482df9153', 'e6661e13-4418-45d3-b96e-e69d4d0a5f06', 'f8bb0e19-b646-400e-94ad-8a06f40d3b01');
Insert into AccountFieldMappings (Id, FieldId, AccountId) Values 
('39422080-e301-47ab-add9-f78ed169dd1a', 'ca23317f-e026-4e5a-b8aa-e5f80027aced', 'de317fd1-ed36-40d6-ac74-5aec009da2ca');
Insert into AccountFieldMappings (Id, FieldId, AccountId) Values 
('79f00d59-15f5-4cab-938b-38bbd511b8af', '908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc0d', 'c5771dfb-21b3-4061-88a7-a6aae4980af2');
Insert into AccountFieldMappings (Id, FieldId, AccountId) Values 
('c44267e4-ee7e-4943-a061-13745c3bf685', 'e6661e13-4418-45d3-b96e-e69d4d0a5f06', 'b365be3d-9559-4e50-8fe9-36a02482087b');
Insert into AccountFieldMappings (Id, FieldId, AccountId) Values 
('8ea8a013-540b-463b-b636-057fcdd840d7', 'ca23317f-e026-4e5a-b8aa-e5f80027aced', 'ca31764c-ab67-4c97-9583-05a0ab9fc9e6');
Insert into AccountFieldMappings (Id, FieldId, AccountId) Values 
('eedd182f-4aef-4e77-b6e8-0f4be1284303', '908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc0d', '20b7459c-4bf7-4a89-b91f-107369043d92');
Insert into AccountFieldMappings (Id, FieldId, AccountId) Values 
('c6d15934-3067-4893-801d-f5f3e7ec7ed0', 'e6661e13-4418-45d3-b96e-e69d4d0a5f06', '2167bd65-cc50-4956-aa44-d07d8ec20854');
Insert into AccountFieldMappings (Id, FieldId, AccountId) Values 
('9f10cc36-608b-40ed-b8e8-91a3d7897a9e', 'ca23317f-e026-4e5a-b8aa-e5f80027aced', '6a84948b-a883-4b11-943d-a8a602796d52');
Insert into AccountFieldMappings (Id, FieldId, AccountId) Values 
('a1caddcf-8da4-4b99-a957-9015721c8521', '908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc0d', '725c507f-60ed-4bca-bbe8-7545dc7b7849');

UPDATE Account
SET AccountFieldMappingId = '7e893b0c-7b3b-4d7b-96cf-322482df9153'
WHERE Id = 'f8bb0e19-b646-400e-94ad-8a06f40d3b01';
UPDATE Account
SET AccountFieldMappingId = '39422080-e301-47ab-add9-f78ed169dd1a'
WHERE Id = 'de317fd1-ed36-40d6-ac74-5aec009da2ca';
UPDATE Account
SET AccountFieldMappingId = '79f00d59-15f5-4cab-938b-38bbd511b8af'
WHERE Id = 'c5771dfb-21b3-4061-88a7-a6aae4980af2';
UPDATE Account
SET AccountFieldMappingId = 'c44267e4-ee7e-4943-a061-13745c3bf685'
WHERE Id = 'b365be3d-9559-4e50-8fe9-36a02482087b';
UPDATE Account
SET AccountFieldMappingId = '8ea8a013-540b-463b-b636-057fcdd840d7'
WHERE Id = 'ca31764c-ab67-4c97-9583-05a0ab9fc9e6';
UPDATE Account
SET AccountFieldMappingId = 'eedd182f-4aef-4e77-b6e8-0f4be1284303'
WHERE Id = '20b7459c-4bf7-4a89-b91f-107369043d92';
UPDATE Account
SET AccountFieldMappingId = 'c6d15934-3067-4893-801d-f5f3e7ec7ed0'
WHERE Id = '2167bd65-cc50-4956-aa44-d07d8ec20854';
UPDATE Account
SET AccountFieldMappingId = '9f10cc36-608b-40ed-b8e8-91a3d7897a9e'
WHERE Id = '6a84948b-a883-4b11-943d-a8a602796d52';
UPDATE Account
SET AccountFieldMappingId = 'a1caddcf-8da4-4b99-a957-9015721c8521'
WHERE Id = '725c507f-60ed-4bca-bbe8-7545dc7b7849';

--- Blog Table ---
Insert into Blog (Id, Thumbnal_Url, Title, Description, Status, ReviewDateTime, CreatedTime, UpdatedTime, [View] , CategoryId, ReviewerId, AuthorId, ReviewFromReviewer,ShortDescription) Values
('eb46d425-4511-4a98-a8ac-80eb8f5352b4','images/github.png', 'What is github', 'GitHub is a for-profit company that offers a cloud-based Git repository hosting service. Essentially, it makes it a lot easier for individuals and teams to use Git for version control and collaboration. GitHub is interface is user-friendly enough so even novice coders can take advantage of Git. Without GitHub, using Git generally requires a bit more technical savvy and use of the command line. Additionally, anyone can sign up and host a public code repository for free, which makes GitHub especially popular with open-source projects.','PENDING', '2023-10-26','2023-10-25','2023-10-26', 0, '6844C8D9-8AC5-4C3D-88D6-76E79F0F0A8A', null, '1E92A1B2-BDCB-4521-BC6F-818B5BD53B98', 'Good Blog','GitHub is a for-profit company that offers a cloud...');
Insert into Blog (Id, Thumbnal_Url, Title, Description, Status, ReviewDateTime, CreatedTime, UpdatedTime, [View] , CategoryId, ReviewerId, AuthorId, ReviewFromReviewer,ShortDescription) Values
('eb46d425-4511-4a98-a8ac-80eb8f5352b5','images/eager.png', 'Eager Loading of Related Data', 'You can use the Include method to specify related data to be included in query results. In the following example, the blogs that are returned in the results will have their Posts property populated with the related posts.You can drill down through relationships to include multiple levels of related data using the ThenInclude method. The following example loads all blogs, their related posts, and the author of each post.','PENDING', '2023-10-26','2023-10-25','2023-10-26', 0, '6844C8D9-8AC5-4C3D-88D6-76E79F0F0A8A', null, 'A4CD997E-5976-4CBB-B45D-B5EBDED9782F', 'Good Blog','You can use the Include method to specify related data to be included in query results. In the following example, the blogs that are returned in the results will have their Posts property populated with the related posts....');
Insert into Blog (Id, Thumbnal_Url, Title, Description, Status, ReviewDateTime, CreatedTime, UpdatedTime, [View] , CategoryId, ReviewerId, AuthorId, ReviewFromReviewer,ShortDescription) Values
('eb46d425-4511-4a98-a8ac-80eb8f5352b6','images/react.png', 'ReactJs', 'React lets you build user interfaces out of individual pieces called components. Create your own React components like Thumbnail, LikeButton, and Video. Then combine them into entire screens, pages, and apps.React components are JavaScript functions. Want to show some content conditionally? Use an if statement. Displaying a list? Try array map(). Learning React is learning programming.','PENDING', '2023-10-26','2023-10-25','2023-10-26', 0, 'AEF378EE-EAC6-4083-B6F2-01AA11C39BE7', null, '725C507F-60ED-4BCA-BBE8-7545DC7B7849', 'Good Blog','This markup syntax is called JSX. It is a JavaScript syntax extension popularized by React. Putting JSX markup close to related rendering logic makes React components easy to create, maintain, and delete....');
Insert into Blog (Id, Thumbnal_Url, Title, Description, Status, ReviewDateTime, CreatedTime, UpdatedTime, [View] , CategoryId, ReviewerId, AuthorId, ReviewFromReviewer,ShortDescription) Values
('eb46d425-4511-4a98-a8ac-80eb8f5352b7','images/react.png', 'ReactJs', 'React lets you build user interfaces out of individual pieces called components. Create your own React components like Thumbnail, LikeButton, and Video. Then combine them into entire screens, pages, and apps.React components are JavaScript functions. Want to show some content conditionally? Use an if statement. Displaying a list? Try array map(). Learning React is learning programming.','PENDING', '2023-10-26','2023-10-25','2023-10-26', 0, 'AEF378EE-EAC6-4083-B6F2-01AA11C39BE7', null, '725C507F-60ED-4BCA-BBE8-7545DC7B7849', 'Good Blog','This markup syntax is called JSX. It is a JavaScript syntax extension popularized by React. Putting JSX markup close to related rendering logic makes React components easy to create, maintain, and delete....');
Insert into Blog (Id, Thumbnal_Url, Title, Description, Status, ReviewDateTime, CreatedTime, UpdatedTime, [View] , CategoryId, ReviewerId, AuthorId, ReviewFromReviewer,ShortDescription) Values
('eb46d425-4511-4a98-a8ac-80eb8f5352b8','images/marketing.png', 'Marketing', 'The AMA’s definitions of marketing and marketing research are reviewed and reapproved/modified regularly by a panel of five scholars who are active researchers.Marketing research is the function that links the consumer, customer, and public to the marketer through information—information used to identify and define opportunities and problems; generate, refine, and evaluate actions; monitor performance; and improve understanding of it as a process. It specifies the information required to address these issues, designs the method for collecting information, manages and implements the data collection process, analyzes the results, and communicates the findings and their implications.','PENDING', '2023-10-26','2023-10-25','2023-10-26', 0, 'D58B7C9C-98BE-46E6-A661-1E0210BD02CE', null, '673D32DD-C157-4AB1-93E1-1315EA6B136F', 'Good Blog','The AMA’s definitions of marketing and marketing research are reviewed and reapproved/modified regularly by a panel of five scholars who are active researchers...');
Insert into Blog (Id, Thumbnal_Url, Title, Description, Status, ReviewDateTime, CreatedTime, UpdatedTime, [View] , CategoryId, ReviewerId, AuthorId, ReviewFromReviewer,ShortDescription) Values
('eb46d425-4511-4a98-a8ac-80eb8f5352b9','images/pronounciation.jpg', 'How to improved pronouciation', 'Listen and write :Take a short clip from a song, film, show or audio file. Write down the words that you hear and replay it until you have got them all. Play it at 0.75x or 0.5x speed if you need to.Then compare your version with the lyrics, transcript or subtitles. Did you get it exactly? Note any differences. This really helps you to focus on particular pronunciation features.Finally, say the words yourself, copying the same sounds that you heard. Repeat the practice until you can pronounce the sounds smoothly and comfortably.2. Speak and check : This is the reverse of the previous tip. Now, you say the words and let a dictation app or website write down what you say.If it writes down what you said correctly, you must have pronounced it well! But if it does not check those misunderstood words because you might not have pronounced them clearly. (Note, however, that dictation programs do sometimes make mistakes.)For this tip, you will need a dictation app or website. Many phones have voice dictation functions. You can also use websites such as (make sure you set the language to English).','PENDING', '2023-10-26','2023-10-25','2023-10-26', 0, '5D57EF10-4CDC-464E-AD52-8D766EF136F8', null, 'A4CD997E-5976-4CBB-B45D-B5EBDED9782F', 'Good Blog','Take a short clip from a song, film, show or audio file. Write down the words that you hear and replay it until you have got them all. Play it at 0.75x or 0.5x speed if you need to.');

-- Blog Approval --
Insert into Blog (Id, Thumbnal_Url, Title, Description, Status, ReviewDateTime, CreatedTime, UpdatedTime, [View], CategoryId, ReviewerId, AuthorId, ReviewFromReviewer, ShortDescription) Values 
('8c644d03-fba0-4e1d-a234-42f9fda03c37', 'images/springBoot.png', 'What is Spring Boot', 'Spring Boot is an open-source Java-based framework used to create stand-alone, production-grade Spring-based applications. It is built on top of the Spring Framework and designed to simplify the setup and development of new Spring applications. Spring Boot simplifies and accelerates the development process of Java applications by providing a production-ready default configuration, embedded servers, dependency management, and a wide range of tools and extensions to build robust and scalable applications.', 'APPROVED', '2023-2-11', '2023-1-11', '2023-1-11', 10, '6844C8D9-8AC5-4C3D-88D6-76E79F0F0A8A', 'F8BB0E19-B646-400E-94AD-8A06F40D3B01', '1E92A1B2-BDCB-4521-BC6F-818B5BD53B98', 'Good Blog', 'Spring Boot is an open-source Java-based framework used to create stand-alone, production-grade Spring-based applications. It is built on top of the Spring Framework and designed to simplify the setup and development of new Spring applications.')
Insert into Blog (Id, Thumbnal_Url, Title, Description, Status, ReviewDateTime, CreatedTime, UpdatedTime, [View], CategoryId, ReviewerId, AuthorId, ReviewFromReviewer, ShortDescription) Values 
('838d102b-7229-47de-953c-17100a263e5d', 'images/pronouce.webp', 'Importance of pronouce in English' , 'The use of pronouns in English is crucial for clear and effective communication. Here is why pronouns are important in the English language Clarity and Precision Pronouns help avoid repetition. Instead of repeating nouns, which can make sentences lengthy and cumbersome, pronouns allow for more concise and clear communication Contextual Understanding: Pronouns provide context to the listener or reader. They indicate who or what the speaker is referring to. Using the correct pronoun ensures that the listener or reader can follow the conversation or text without confusion.', 'APPROVED' ,'2023-11-2' ,'2023-11-1' ,'2023-11-1' , 5, '5d57ef10-4cdc-464e-ad52-8d766ef136f8', 'C5771DFB-21B3-4061-88A7-A6AAE4980AF2', '1E92A1B2-BDCB-4521-BC6F-818B5BD53B98', 'Quite Good but make sure you are own practice it', 'The use of pronouns in English is crucial for clear and effective communication. Here is why pronouns are important in the English language Clarity and Precision Pronouns help avoid repetition. Instead of repeating nouns, which can make sentences lengthy and cumbersome, pronouns allow for more concise and clear communication')
Insert into Blog (Id, Thumbnal_Url, Title, Description, Status, ReviewDateTime, CreatedTime, UpdatedTime, [View], CategoryId, ReviewerId, AuthorId, ReviewFromReviewer, ShortDescription) Values 
('eaf77415-c576-4b4a-b2a1-279750efe588', 'images/css&html.png', 'Understand of CSS&HTML', 'HTML (HyperText Markup Language) and CSS (Cascading Style Sheets) are fundamental technologies for building websites. Here is why they are important and how they work together Structure and Content (HTML): HTML provides the basic structure and content of a web page. It defines elements such as headings, paragraphs, links, images, forms, and more. HTML serves as the backbone, organizing the information that is displayed on a web page.Presentation and Styling (CSS):CSS is used for presentation and styling. It controls the layout, colors, fonts, and overall visual presentation of a web page. CSS allows developers to style HTML elements and make the website visually appealing. It separates the content (HTML) from its presentation (CSS), promoting a cleaner and more maintainable code structure.', 'APPROVED', '2023-11-02', '2023-11-1', '2023-11-1', 10, 'AEF378EE-EAC6-4083-B6F2-01AA11C39BE7', 'F8BB0E19-B646-400E-94AD-8A06F40D3B01', '1E92A1B2-BDCB-4521-BC6F-818B5BD53B98', 'Amazing', 'HTML (HyperText Markup Language) and CSS (Cascading Style Sheets) are fundamental technologies for building websites. Here is why they are important and how they work together Structure and Content (HTML): HTML provides the basic structure and content of a web page.')
Insert into Blog (Id, Thumbnal_Url, Title, Description, Status, ReviewDateTime, CreatedTime, UpdatedTime, [View], CategoryId, ReviewerId, AuthorId, ReviewFromReviewer, ShortDescription) Values 
('5e2ba2be-7108-426a-83bb-16f151400e39', 'images/chinaLanguage.png', 'Faster learning China', 'Learning any language, including Chinese, takes time, dedication, and consistent effort. However, there are strategies you can employ to make your learning process more efficient and effective. Here are some tips to help you learn Chinese more quickly Set Clear Goals: Define your goals for learning Chinese. Whether you want to travel, communicate with friends and family, or do business, having clear objectives will keep you motivated.Start with Basics: Focus on learning essential vocabulary, phrases, and basic grammar structures. Mastering the fundamentals will provide a strong foundation for more advanced learning.', 'APPROVED', '2023-11-2', '2023-11-1', '2023-11-1', 143, '8A8BDB56-B488-4460-B922-9CAE647BC027', 'C5771DFB-21B3-4061-88A7-A6AAE4980AF2', '673D32DD-C157-4AB1-93E1-1315EA6B136F', 'Well done you have a big fan on this', 'Learning any language, including Chinese, takes time, dedication, and consistent effort. However, there are strategies you can employ to make your learning process more efficient and effective. Here are some tips to help you learn Chinese more quickly')
Insert into Blog (Id, Thumbnal_Url, Title, Description, Status, ReviewDateTime, CreatedTime, UpdatedTime, [View], CategoryId, ReviewerId, AuthorId, ReviewFromReviewer, ShortDescription) Values 
('654e4796-c588-4fae-b931-f405665e091a', 'images/sap.png', 'What is SAP', 'SAP (Systems, Applications, and Products) is a leading enterprise resource planning (ERP) software that helps businesses manage their operations and customer relations efficiently. For developers, SAP offers a comprehensive set of tools, technologies, and platforms to design, develop, and customize SAP applications and solutions. Here is what SAP entails for developers SAP provides a wide array of tools and technologies that cater to developers needs, ranging from programming languages like ABAP to modern web development frameworks like SAPUI5, enabling the creation of tailored enterprise solutions and integrations.', 'APPROVED', '2023-11-2', '2023-11-1', '2023-11-1', 0, '6CBC7902-573B-42B9-94A0-A187290A500C', 'F8BB0E19-B646-400E-94AD-8A06F40D3B01', 'A4CD997E-5976-4CBB-B45D-B5EBDED9782F', 'Great', 'SAP (Systems, Applications, and Products) is a leading enterprise resource planning (ERP) software that helps businesses manage their operations and customer relations efficiently. For developers, SAP offers a comprehensive set of tools, technologies, and platforms to design, develop, and customize SAP applications and solutions. Here is what SAP entails for developers')


--- Category Table ---
Insert into Category (Id, Name, Status, FieldId) Values ('aef378ee-eac6-4083-b6f2-01aa11c39be7', 'Font-End', 'ACTIVE', 'e6661e13-4418-45d3-b96e-e69d4d0a5f06');
Insert into Category (Id, Name, Status, FieldId) Values ('6844c8d9-8ac5-4c3d-88d6-76e79f0f0a8a', 'Back-End', 'ACTIVE', 'e6661e13-4418-45d3-b96e-e69d4d0a5f06');
Insert into Category (Id, Name, Status, FieldId) Values ('6cbc7902-573b-42b9-94a0-a187290a500c', 'SAP', 'ACTIVE', 'e6661e13-4418-45d3-b96e-e69d4d0a5f06');
Insert into Category (Id, Name, Status, FieldId) Values ('eba9f435-b36d-4317-9507-ec89955df639', 'BA', 'ACTIVE', 'e6661e13-4418-45d3-b96e-e69d4d0a5f06');
Insert into Category (Id, Name, Status, FieldId) Values ('d58b7c9c-98be-46e6-a661-1e0210bd02ce', 'Marketing', 'ACTIVE', 'ca23317f-e026-4e5a-b8aa-e5f80027aced');
Insert into Category (Id, Name, Status, FieldId) Values ('0043c257-b849-4770-bf7f-be00a33fc383', 'Economics', 'ACTIVE', 'ca23317f-e026-4e5a-b8aa-e5f80027aced');
Insert into Category (Id, Name, Status, FieldId) Values ('709707bc-9d4a-4ce4-a95c-526bc7fd262b', 'Finance', 'ACTIVE', 'ca23317f-e026-4e5a-b8aa-e5f80027aced');
Insert into Category (Id, Name, Status, FieldId) Values ('5d57ef10-4cdc-464e-ad52-8d766ef136f8', 'English', 'ACTIVE', '908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc0d');
Insert into Category (Id, Name, Status, FieldId) Values ('13f138da-15de-49e1-9cba-db7f64f11c56', 'Japan', 'ACTIVE', '908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc0d');
Insert into Category (Id, Name, Status, FieldId) Values ('8a8bdb56-b488-4460-b922-9cae647bc027', 'China', 'ACTIVE', '908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc0d');


--- BannedInfors ---
Insert into BannedInfors (Id, Reason, AccountId, DateBanned) Values
('91bca15e-0ce5-4bf0-bd28-6e5b6e2c71ac', 'Toxic', '673D32DD-C157-4AB1-93E1-1315EA6B136F', '2023-10-1');

--- Comment table ---
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc0c',N'good blog','2023-10-28',null,'a4cd997e-5976-4cbb-b45d-b5ebded9782f','eb46d425-4511-4a98-a8ac-80eb8f5352b9')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc02',N'i agree with u','2023-10-28','908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc0c','7d696a6f-dd79-4b56-9863-e72d15c3faa6','eb46d425-4511-4a98-a8ac-80eb8f5352b9')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc03',N'thank you for blog','2023-10-28',null,'7d696a6f-dd79-4b56-9863-e72d15c3faa6','eb46d425-4511-4a98-a8ac-80eb8f5352b8')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc04',N'it is interesting','2023-10-28',null,'b365be3d-9559-4e50-8fe9-36a02482087b','eb46d425-4511-4a98-a8ac-80eb8f5352b8')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc05',N'that is true','2023-10-28','908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc04','de317fd1-ed36-40d6-ac74-5aec009da2ca','eb46d425-4511-4a98-a8ac-80eb8f5352b8')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc06',N'you are nice','2023-10-28',null,'1e92a1b2-bdcb-4521-bc6f-818b5bd53b98','eb46d425-4511-4a98-a8ac-80eb8f5352b7')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc07',N'yes author is good blogger','2023-10-28','908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc06','2167bd65-cc50-4956-aa44-d07d8ec20854','eb46d425-4511-4a98-a8ac-80eb8f5352b7')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc08',N'hope for next blog','2023-10-28',null,'2167bd65-cc50-4956-aa44-d07d8ec20854','eb46d425-4511-4a98-a8ac-80eb8f5352b6')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc09',N'I hope so','2023-10-28','908fe5a2-f1d0-44e9-a4c2-e7f53fa2cc08','7d696a6f-dd79-4b56-9863-e72d15c3faa6','eb46d425-4511-4a98-a8ac-80eb8f5352b6')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('3afcab27-0641-4b60-aff1-d7eed068603c',N'hope for next blog','2023-10-28',null,'2167bd65-cc50-4956-aa44-d07d8ec20854','eb46d425-4511-4a98-a8ac-80eb8f5352b5')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('c202a3f4-0092-4739-8e27-e70055ac80ec',N'I hope so','2023-10-28','3afcab27-0641-4b60-aff1-d7eed068603c','7d696a6f-dd79-4b56-9863-e72d15c3faa6','eb46d425-4511-4a98-a8ac-80eb8f5352b5')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('b48dd6a6-b222-4cbe-a251-7fb9c4e34315',N'hope for next blog','2023-10-28',null,'2167bd65-cc50-4956-aa44-d07d8ec20854','eb46d425-4511-4a98-a8ac-80eb8f5352b4')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('82cbe17b-3cf2-4d7f-90fd-98c38efbeb75',N'I hope so','2023-10-28','b48dd6a6-b222-4cbe-a251-7fb9c4e34315','7d696a6f-dd79-4b56-9863-e72d15c3faa6','eb46d425-4511-4a98-a8ac-80eb8f5352b4')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('fe0f6066-505e-47e6-9e9c-5d5c83b1fe46', 'Nice blog it help me a lot', '2023-11-2', null, '673D32DD-C157-4AB1-93E1-1315EA6B136F', '8c644d03-fba0-4e1d-a234-42f9fda03c37')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('57b0a86e-ef0e-488b-8ee7-6c29d9ee3862', 'Thanks i doing all my best', '2023-11-2', 'fe0f6066-505e-47e6-9e9c-5d5c83b1fe46', '1E92A1B2-BDCB-4521-BC6F-818B5BD53B98', '8c644d03-fba0-4e1d-a234-42f9fda03c37')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('0592cd5b-1a54-4cef-bb7f-81a4feabbd2d', 'You doing great', '2023-11-2', '57b0a86e-ef0e-488b-8ee7-6c29d9ee3862', '673D32DD-C157-4AB1-93E1-1315EA6B136F', '8c644d03-fba0-4e1d-a234-42f9fda03c37')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('a7bfb6c0-6155-4f03-8ec9-0dab109a044e', 'New information asobted', '2023-11-2', null, 'A4CD997E-5976-4CBB-B45D-B5EBDED9782F', '8c644d03-fba0-4e1d-a234-42f9fda03c37')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('ad057c4d-3ddc-4138-8129-06202f2d6b31', 'Thanks', '2023-11-2', 'a7bfb6c0-6155-4f03-8ec9-0dab109a044e', '673D32DD-C157-4AB1-93E1-1315EA6B136F', '8c644d03-fba0-4e1d-a234-42f9fda03c37')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('b4abc149-282a-4631-ae61-177ed64f8960', 'Finally a great blog i ever find', '2023-11-2', null, '673D32DD-C157-4AB1-93E1-1315EA6B136F', '838d102b-7229-47de-953c-17100a263e5d')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('d53e0bf4-dcc6-4025-9ee8-607b0f482a0d', 'Amazing this blog gimme everythings i want', '2023-11-2', null, 'A4CD997E-5976-4CBB-B45D-B5EBDED9782F', '838d102b-7229-47de-953c-17100a263e5d')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('33276760-7134-4c1c-8e8d-df607cfcabd1', 'Nice you spend a lot of time on this blog', '2023-11-2', null, '7D696A6F-DD79-4B56-9863-E72D15C3FAA6', '838d102b-7229-47de-953c-17100a263e5d')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('1d9e584f-0fe0-47aa-97e5-ae7b6757f865', 'Good blog bro', '2023-11-2', null, '673D32DD-C157-4AB1-93E1-1315EA6B136F', 'eaf77415-c576-4b4a-b2a1-279750efe588')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('59a590ac-02ba-4029-ba81-5eb831730ea8', 'Keep your style', '2023-11-2', null, '7D696A6F-DD79-4B56-9863-E72D15C3FAA6', 'eaf77415-c576-4b4a-b2a1-279750efe588')
Insert into Comment (Id,Content,CreateTime,ReplyToId,CommentorId,BlogId) Values ('aa95b8c0-09ac-4641-82d4-c8a44ef4f248', 'Look at this blog how impressive', '2023-11-2', null, '673D32DD-C157-4AB1-93E1-1315EA6B136F', '5e2ba2be-7108-426a-83bb-16f151400e39')


--- Award Table ---
Insert into Awards (Id, Name) Values ('3a7077a6-c515-4d58-b6a1-e1a785cc2561', '[Blog View Champion] [Basic] [3]');
Insert into Awards (Id, Name) Values ('e4be5f9c-1404-4ead-bc5c-5dcf1d52c706', '[Blog View Champion] [Advance] [5]');
Insert into Awards (Id, Name) Values ('eca5530f-1e0d-4bfb-8fb6-d587f93de311', '[Blog View Champion] [Master] [10]');
Insert into Awards (Id, Name) Values ('3bc05f9d-f639-4f09-894b-c88998269984', '[Blogging Machine] [Basic] [1]');
Insert into Awards (Id, Name) Values ('d57a95f3-e6e1-4116-b258-5b0985030534', '[Blogging Machine] [Advance] [3]');
Insert into Awards (Id, Name) Values ('290e05ec-8285-4c50-8af1-e2e317008939', '[Blogging Machine] [Master] [5]');
Insert into Awards (Id, Name) Values ('69f6ac85-0424-47f3-9344-938346897bfe', '[Most Viewed Blog] [Basic] [3]');
Insert into Awards (Id, Name) Values ('f34480fb-ffe5-423e-a627-818c524ddc3d', '[Most Viewed Blog] [Advance] [5]');
Insert into Awards (Id, Name) Values ('9f87bf5b-01d3-4d37-a07f-68c0a9428c8e', '[Most Viewed Blog] [Master] [10]');
Insert into Awards (Id, Name) Values ('85b853bf-657a-4d4f-88dc-17016ea8231c', '[Most Viewd Blog] [God] [20]');
Insert into Awards (Id, Name) Values ('c667a31e-a875-47dc-92e4-3f63128f2b65', '[Comment Machine] [Basic] [3]');
Insert into Awards (Id, Name) Values ('e02b53c4-622d-4f01-b50c-30c103dad615', '[Comment Machine] [Advance] [5]');
Insert into Awards (Id, Name) Values ('c746f0bc-b8b5-428e-b273-a82d534c5880', '[Comment Machine] [Master] [10]');
Insert into Awards (Id, Name) Values ('65acf28e-a39e-448c-b39c-75921e13d15e', '[Adwards Enred] [Basic] [3]');
Insert into Awards (Id, Name) Values ('b1b84e83-a538-46f8-b2b2-f4b3f7098071', '[Adwards Enred] [Advance] [5]');
Insert into Awards (Id, Name) Values ('1d4dfa60-6aec-46d5-801b-9f4d46939af3', '[Adwards Enred] [Master] [8]');
Insert into Awards (Id, Name) Values ('06eccbcf-9fb6-4140-b344-356d3307ae12', '[Adwards Enred] [God] [13]');

--- AccountAwardMapping ---
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values ('ea042526-819c-419c-8ffb-ab7426b9d67a', '2023-11-2', '1E92A1B2-BDCB-4521-BC6F-818B5BD53B98', '3a7077a6-c515-4d58-b6a1-e1a785cc2561');
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values  ('622542ef-389e-4549-9d75-0594b61eb6a2', '2023-11-2', '1E92A1B2-BDCB-4521-BC6F-818B5BD53B98', 'e4be5f9c-1404-4ead-bc5c-5dcf1d52c706');
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values  ('3fe65e76-8f4b-444b-bf2c-9504357c372a', '2023-11-2', '1E92A1B2-BDCB-4521-BC6F-818B5BD53B98', 'eca5530f-1e0d-4bfb-8fb6-d587f93de311');
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values ('c21953f2-a8ba-449e-81d9-af98ce32eeaa', '2023-11-2', '1E92A1B2-BDCB-4521-BC6F-818B5BD53B98', 'c667a31e-a875-47dc-92e4-3f63128f2b65');
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values ('982187d6-2674-43c4-b3ea-13851ee2905e', '2023-11-2', '1E92A1B2-BDCB-4521-BC6F-818B5BD53B98', '65acf28e-a39e-448c-b39c-75921e13d15e');
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values ('10c840a5-5a30-4049-9899-cb0eaeb82a6d', '2023-11-2', '673D32DD-C157-4AB1-93E1-1315EA6B136F', '3bc05f9d-f639-4f09-894b-c88998269984');
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values  ('e3aa12ae-e1f9-4733-bc35-b305a1d732d0', '2023-11-2', '673D32DD-C157-4AB1-93E1-1315EA6B136F', 'c667a31e-a875-47dc-92e4-3f63128f2b65');
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values ('9453773b-ec3d-479f-8532-82acaf03b34b', '2023-11-2', 'A4CD997E-5976-4CBB-B45D-B5EBDED9782F', '69f6ac85-0424-47f3-9344-938346897bfe');
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values ('c6fa60cb-8d62-4e25-ac90-95d621bcd338', '2023-11-2', '7D696A6F-DD79-4B56-9863-E72D15C3FAA6', 'c667a31e-a875-47dc-92e4-3f63128f2b65');
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values ('3bbb7ba8-a36b-4bcf-8484-eafb9ee1eb27', '2023-11-2', '7D696A6F-DD79-4B56-9863-E72D15C3FAA6', 'e02b53c4-622d-4f01-b50c-30c103dad615');
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values ('152f1b6a-0795-407e-aa1b-2f7ccba9d909', '2023-11-2', '7D696A6F-DD79-4B56-9863-E72D15C3FAA6', '3a7077a6-c515-4d58-b6a1-e1a785cc2561');
Insert into AccountAwardMapping (Id, DateTime, StudentId, AwardId) Values ('b1b8fc58-8375-4bd7-988b-9bd7b33ac998', '2023-11-2', '7D696A6F-DD79-4B56-9863-E72D15C3FAA6', '65acf28e-a39e-448c-b39c-75921e13d15e');