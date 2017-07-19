package jp.co.isid.ham.media.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* ラジオ番組登録画面登録結果セット
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class RegisterRdProgramInfoResult extends AbstractServiceResult {

    /** ラジオ番組SEQNO(新規用) */
    private BigDecimal _rdSeqNo = BigDecimal.valueOf(0);

    /** ダミープロパティ */
    private String _dummy = null;

    /**
     * ラジオ番組SEQNO(新規用)を取得する
     * @return BigDecimal ラジオ番組SEQNO(新規用)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRdSeqNo() {
        return _rdSeqNo;
    }

    /**
     * ラジオ番組SEQNO(新規用)を設定する
     * @param val BigDecimal ラジオ番組SEQNO(新規用)
     */
    public void setRdSeqNo(BigDecimal val) {
        _rdSeqNo = val;
    }

    /**
     * ダミープロパティを取得する
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ダミープロパティを設定する
     * @param val String ダミープロパティ
     */
    public void setDummy(String val) {
        _dummy = val;
    }

}
