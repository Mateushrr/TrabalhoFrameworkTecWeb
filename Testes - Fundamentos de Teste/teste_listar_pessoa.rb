# frozen_string_literal: true

require 'watir'
require 'webdrivers/chromedriver'

Watir.logger.level = :warn
Watir.logger.output = 'watir.log'

browser = Watir::Browser.start 'https://localhost', :chrome, headless: false
browser.link(text: 'Listar').wait_until(&:present?).click

if browser.table(class: 'table').exist?
  Watir.logger.warn('Carregado corretamente.')
elsif Watir.logger.warn('Não foi carregado corretamente.')
end

sleep(10)
