# frozen_string_literal: true

require 'watir'
require 'webdrivers/chromedriver'

Watir.logger.level = :warn
Watir.logger.output = 'watir.log'

browser = Watir::Browser.start 'https://localhost', :chrome, headless: false
browser.link(text: 'Listar').wait_until(&:present?).click

tamanho_tabela = browser.table(class: 'table').count - 1

while tamanho_tabela != 0
  browser.table(class: 'table')[1][4].link(text: 'Deletar').click
  tamanho_tabela -= 1
end

sleep(10)
