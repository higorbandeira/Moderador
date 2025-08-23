from openai import OpenAI

client = OpenAI(
  api_key=""
)

response = client.responses.create(
  model="gpt-4o-mini",
  input="Say Hello World",
  store=True,
)

print(response.output_text)
