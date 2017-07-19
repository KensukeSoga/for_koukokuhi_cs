package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataVO;

/**
 * <P>
 * CR制作費管理の登録処理用のCR制作費管理VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/07 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class Tbj11CrCreateDataForUpdVO extends Tbj11CrCreateDataVO {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj11CrCreateDataForUpdVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj11CrCreateDataForUpdVO();
    }

    private String _inputTntNm = null;

    /**
     * 入力担当者名を取得する
     * @return
     */
    public String getInputTntNm() {
        return _inputTntNm;
    }

    /**
     * 入力担当者名を設定する
     * @param inputTntNm
     */
    public void setInputTntNm(String inputTntNm) {
        _inputTntNm = inputTntNm;
    }
}
