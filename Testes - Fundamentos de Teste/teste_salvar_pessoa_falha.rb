# frozen_string_literal: true

require 'watir'
require 'webdrivers/chromedriver'
require 'faker'

Watir.logger.level = :warn
Watir.logger.output = 'watir.log'

browser = Watir::Browser.start 'https://localhost', :chrome, headless: false
browser.link(text: 'Cadastrar').wait_until(&:present?).click

cpf = Faker::Number.decimal_part(digits: 3) + '' + Faker::Number.decimal_part(digits: 3) + '' \
      + Faker::Number.decimal_part(digits: 3) + '' + Faker::Number.decimal_part(digits: 2)

nome = Faker::Name.first_name + ' ' + Faker::Name.last_name + '' + Faker::Number.decimal_part(digits: 2)
idade = Faker::Number.between(from: 120, to: 200)
email = 'email@br'

browser.text_field(name: 'cpf').set cpf
browser.text_field(name: 'nome').set nome
browser.text_field(name: 'idade').set idade
browser.text_field(name: 'email').set email
browser.button(text: 'Cadastrar').click

Watir.logger.warn('cpf ' + cpf + ' inválido.') if browser.span(text: /CPF inválido./).exist?
Watir.logger.warn('nome ' + nome + ' inválido.') if browser.span(text: /Nomes não devem conter números./).exist?
Watir.logger.warn('idade ' + String(idade) + ' inválida.') if browser.span(text: /Idade válida entre./).exist?
Watir.logger.warn('email ' + email + ' inválido.') if browser.span(text: /O email é inválido./).exist?

sleep(10)
