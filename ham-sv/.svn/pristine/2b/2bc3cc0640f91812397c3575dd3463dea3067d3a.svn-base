package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;

/**
 * <P>
 * 素材一覧　登録用一覧データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/05 新HAMチーム)<BR>
 * ・JASRAC対応(2015/11/19 HLC K.Soga)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterMaterialListUpdateVO extends Tbj20SozaiKanriListVO {

    private static final long serialVersionUID = 1L;

    /**
     * 変更前車種コード
     */
    private String _prevDCarCd = null;

    /** 2015/10/14 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 系統
     */
    private String _NoKbn = null;
    /** 2015/10/14 JASRAC対応 HLC K.Soga ADD End */

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RegisterMaterialListUpdateVO();
    }

    /**
     * 変更前車種コードを設定します
     * @param val
     */
    public void setPrevDCarCd(String val) {
        _prevDCarCd = val;
    }

    /**
     * 変更前車種コードを取得します
     * @return
     */
    public String getPrevDCarCd() {
        return _prevDCarCd;
    }

    /** 2015/10/14 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 系統を取得する
     *
     * @return 系統
     */
    public String getNOKBN() {
        return _NoKbn;
    }

    /**
     * 系統を設定する
     *
     * @param val 系統
     */
    public void setNOKBN(String val) {
        _NoKbn = val;
    }
    /** 2015/10/14 JASRAC対応 HLC K.Soga ADD End */
}