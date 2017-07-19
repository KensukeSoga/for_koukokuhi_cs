package jp.co.isid.ham.production.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 契約情報登録画面削除ボタン押下時データ取得の条件クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/14 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractDeleteCondition implements Serializable {
    /**
    *
    */
   private static final long serialVersionUID = 1L;

    /** 契約種類*/
   private String strCtrtKbn;
    /** 契約コード*/
   private String strCtrtNo;

    /**
     * 契約種類を取得する
     *
     * @return 契約種類
     */
    public String getStrCtrtKbn() {
        return strCtrtKbn;
    }

    /**
     * 契約種類を設定する
     *
     * @param strCtrtKbn 契約種類
     */
    public void setStrCtrtKbn(String strCtrtKbn) {
        this.strCtrtKbn = strCtrtKbn;
    }

    /**
     * 契約コードを取得する
     *
     * @return 契約コード
     */
    public String getStrCtrtNo() {
        return strCtrtNo;
    }

    /**
     * 契約コードを設定する
     *
     * @param strCtrtNo 契約コード
     */
    public void setStrCtrtNo(String strCtrtNo) {
        this.strCtrtNo = strCtrtNo;
    }
}
