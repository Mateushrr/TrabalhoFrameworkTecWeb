# frozen_string_literal: true

require 'watir'
require 'webdrivers/chromedriver'
require 'faker'

Watir.logger.level = :warn
Watir.logger.output = 'watir.log'

browser = Watir::Browser.start 'https://localhost', :chrome, headless: false
browser.link(text: 'Listar').wait_until(&:present?).click

tamanho_tabela = browser.table(class: 'table').count - 1

while tamanho_tabela != 0
  browser.table(class: 'table')[tamanho_tabela][4].link(text: 'Editar').click

  cpf = Faker::Number.decimal_part(digits: 3) + '.' + Faker::Number.decimal_part(digits: 3) + '.' \
      + Faker::Number.decimal_part(digits: 3) + '-' + Faker::Number.decimal_part(digits: 2)

  browser.text_field(name: 'cpf').set cpf
  browser.text_field(name: 'nome').set Faker::Name.first_name + ' ' + Faker::Name.last_name
  browser.text_field(name: 'idade').set Faker::Number.between(from: 1, to: 120)
  browser.text_field(name: 'email').set Faker::Internet.email
  browser.button(text: 'Salvar').click

  email_invalido = browser.span(text: /O email é inválido./).exist?
  mome_invalido = browser.span(text: /Nomes não devem conter números./).exist?

  while mome_invalido
    browser.text_field(name: 'nome').set Faker::Name.first_name + ' ' + Faker::Name.last_name
    browser.button(text: 'Salvar').click
    mome_invalido = browser.span(text: /Nomes não devem conter números./).exist?
  end

  while email_invalido
    browser.text_field(name: 'email').set Faker::Internet.email
    browser.button(text: 'Salvar').click
    email_invalido = browser.span(text: /O email é inválido./).exist?
  end

  tamanho_tabela -= 1
end

sleep(10)
