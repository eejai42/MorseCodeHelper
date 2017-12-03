<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:param name="output-filename" select="'output.txt'" />

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/*">
        <FileSet>
            <FileSetFiles>
               <FileSetFile>
                    <RelativePath>
                        <xsl:text>Readme.md</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve">Markdown</xsl:element>
                    </FileSetFile>
                <FileSetFile>
                    <RelativePath>
                        <xsl:text>index.html</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve"><html>
    <body>
        <h1>Morse Code</h1>
        <p>
            Currently the Morse Code SDK includes representations for <xsl:value-of select="count(//Alphabets)"/> morse alphabets.  They are 
            similar to one another, but differ in some key ways.  Details of each alphabet is listed below.
        </p>
        <p>
            <xsl:for-each select="//Alphabets">
                    <h2><xsl:value-of select="Name" /></h2>
                <div>
                </div>
                <p>
                    This alphabet has the following characters defined:
                </p>
                <table>
                <tr>
                    <th>Character</th>
                    <th>Code</th>
                    <th>Details</th>
                </tr>
                <xsl:for-each select="./Characters">
                    <xsl:sort select="Name"/>
                    <tr>
                        <td><xsl:value-of select="Name"/></td>
                        <td><xsl:value-of select="SequenceCode"/></td>
                        <td><xsl:for-each select="./CharacterSquences">
                            &lt;img src="images/<xsl:value-of select="//Signals[SignalId = current()/SignalId]/Name" />.png" style="float: left" />                                
                        </xsl:for-each></td>
                    </tr>
                </xsl:for-each>
                </table>
            </xsl:for-each>
        </p>
    </body>
</html>
</xsl:element>
                </FileSetFile>s
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>
