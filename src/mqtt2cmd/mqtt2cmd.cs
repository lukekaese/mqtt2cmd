using System;
using System.IO;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System.Threading.Tasks;
using CommandLine;
using System.Text;

class mqtt2cmd
{
	public class Options
	{
		[Option('s', "server", Required = true, HelpText = "MQTT server address.")]
		public string Server { get; set; }

		[Option('t', "topic", Required = true, HelpText = "MQTT topic to publish to.")]
		public string Topic { get; set; }

		[Option('m', "message", Required = true, HelpText = "Message payload (Text)")]
		public string Message { get; set; }
	}

	static async Task Main(string[] args)
	{
		Parser.Default.ParseArguments<Options>(args)
			  .WithParsedAsync(RunWithOptions)
			  .Wait();
	}


	static async Task RunWithOptions(Options args)
	{
		try
		{


			string messagePayload = args.Message;

			MqttFactory? mqttFactory = new();
			var mqttClient = mqttFactory.CreateMqttClient();

			MqttClientOptions? options = new MqttClientOptionsBuilder()
				.WithTcpServer(args.Server)
				.Build();

			try
			{
				Console.WriteLine($"Trying to Connect to MQTT server {args.Server} ...");
				await mqttClient.ConnectAsync(options);

				Console.WriteLine($"Publishing message to topic {args.Topic} ...");
				MqttApplicationMessage? message = new MqttApplicationMessageBuilder()
					.WithTopic(args.Topic)
					.WithPayload(messagePayload)
					.WithQualityOfServiceLevel(MqttQualityOfServiceLevel.ExactlyOnce)
					.WithRetainFlag(false)
					.Build();

				await mqttClient.PublishAsync(message);
				Console.WriteLine("Message was published");
			}
			catch (Exception ex)
			{
				throw new Exception($"Problem during Publishing: {ex.Message}");
			}
			finally
			{
				await mqttClient.DisconnectAsync();
				Console.WriteLine("Connection Closed");
			}
		}
		catch (Exception ex) {
			Console.WriteLine(ex.Message);
			return;
		}
	}
}