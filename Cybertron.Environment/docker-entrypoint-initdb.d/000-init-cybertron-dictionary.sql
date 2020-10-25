set timezone to 'America/Sao_Paulo';
create schema cybertron;

create table cybertron.dictionary (
  id serial primary key,
  word varchar(30) not null,
  description varchar(250) not null,
  included_at timestamp default current_timestamp,
  altered_at timestamp null
);

insert into cybertron.dictionary (word, description)
values 
('Freezing', 'It is a word that descripes the climatic temperatures'),
('Bracing', 'It is a word that descripes the climatic temperatures'),
('Chilly', 'It is a word that descripes the climatic temperatures'),
('Cool', 'It is a word that descripes the climatic temperatures'),
('Mild', 'It is a word that descripes the climatic temperatures'),
('Warm', 'It is a word that descripes the climatic temperatures'),
('Balmy', 'It is a word that descripes the climatic temperatures'),
('Hot', 'It is a word that descripes the climatic temperatures'),
('Sweltering', 'It is a word that descripes the climatic temperatures'),
('Scorching', 'It is a word that descripes the climatic temperatures');