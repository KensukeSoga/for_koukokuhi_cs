package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Vbj02TitleClassGroupInfo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 新HAM向けVIEW(職位等級グループ情報)VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Vbj02TitleClassGroupInfoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Vbj02TitleClassGroupInfoVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Vbj02TitleClassGroupInfoVO();
    }

    /**
     * グループコードを取得する
     *
     * @return グループコード
     */
    public String getGROUPCD() {
        return (String) get(Vbj02TitleClassGroupInfo.GROUPCD);
    }

    /**
     * グループコードを設定する
     *
     * @param val グループコード
     */
    public void setGROUPCD(String val) {
        set(Vbj02TitleClassGroupInfo.GROUPCD, val);
    }

    /**
     * グループ名称漢字を取得する
     *
     * @return グループ名称漢字
     */
    public String getGROUPNMKJ() {
        return (String) get(Vbj02TitleClassGroupInfo.GROUPNMKJ);
    }

    /**
     * グループ名称漢字を設定する
     *
     * @param val グループ名称漢字
     */
    public void setGROUPNMKJ(String val) {
        set(Vbj02TitleClassGroupInfo.GROUPNMKJ, val);
    }

    /**
     * グループ名称アルファベットを取得する
     *
     * @return グループ名称アルファベット
     */
    public String getGROUPNMALPH() {
        return (String) get(Vbj02TitleClassGroupInfo.GROUPNMALPH);
    }

    /**
     * グループ名称アルファベットを設定する
     *
     * @param val グループ名称アルファベット
     */
    public void setGROUPNMALPH(String val) {
        set(Vbj02TitleClassGroupInfo.GROUPNMALPH, val);
    }

    /**
     * 開始年月日を取得する
     *
     * @return 開始年月日
     */
    public String getSTRTYMD() {
        return (String) get(Vbj02TitleClassGroupInfo.STRTYMD);
    }

    /**
     * 開始年月日を設定する
     *
     * @param val 開始年月日
     */
    public void setSTRTYMD(String val) {
        set(Vbj02TitleClassGroupInfo.STRTYMD, val);
    }

    /**
     * 終了年月日を取得する
     *
     * @return 終了年月日
     */
    public String getSTPYMD() {
        return (String) get(Vbj02TitleClassGroupInfo.STPYMD);
    }

    /**
     * 終了年月日を設定する
     *
     * @param val 終了年月日
     */
    public void setSTPYMD(String val) {
        set(Vbj02TitleClassGroupInfo.STPYMD, val);
    }

}
