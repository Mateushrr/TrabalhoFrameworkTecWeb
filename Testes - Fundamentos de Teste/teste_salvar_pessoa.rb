# frozen_string_literal: true

require 'watir'
require 'webdrivers/chromedriver'
require 'faker'

Watir.logger.level = :warn
Watir.logger.output = 'watir.log'

browser = Watir::Browser.start 'https://localhost', :chrome, headless: false
browser.link(text: 'Cadastrar').wait_until(&:present?).click
quantidade = 0

while quantidade < 5
  cpf = Faker::Number.decimal_part(digits: 3) + '.' + Faker::Number.decimal_part(digits: 3) + '.' \
      + Faker::Number.decimal_part(digits: 3) + '-' + Faker::Number.decimal_part(digits: 2)

  nome = Faker::Name.first_name + ' ' + Faker::Name.last_name

  browser.text_field(name: 'cpf').set cpf
  browser.text_field(name: 'nome').set nome
  browser.text_field(name: 'idade').set Faker::Number.between(from: 1, to: 120)
  browser.text_field(name: 'email').set Faker::Internet.email
  browser.button(text: 'Cadastrar').click

  email_invalido = browser.span(text: /O email é inválido./).exist?
  mome_invalido = browser.span(text: /Nomes não devem conter números./).exist?

  while mome_invalido
    nome = Faker::Name.first_name + ' ' + Faker::Name.last_name
    browser.text_field(name: 'nome').set nome
    browser.button(text: 'Cadastrar').click
    mome_invalido = browser.span(text: /Nomes não devem conter números./).exist?
  end

  while email_invalido
    browser.text_field(name: 'email').set Faker::Internet.email
    browser.button(text: 'Cadastrar').click
    email_invalido = browser.span(text: /O email é inválido./).exist?
  end

  if browser.wait_until.div(text: /cadastrado com sucesso./).exist?
    Watir.logger.warn(nome + ' cadastrado corretamente.')
  elsif Watir.logger.warn(nome + ' não foi cadastrado corretamente.')
  end

  browser.goto('https://localhost/Pessoa/Create')
  quantidade += 1
end

sleep(10)
