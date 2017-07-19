package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj33FunctionControl;
import jp.co.isid.ham.integ.tbl.Mbj34FunctionControlItem;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 機能制御情報VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/11 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FunctionControlInfoVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FunctionControlInfoVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new FunctionControlInfoVO();
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHAMID()
    {
        return (String) get(Mbj33FunctionControl.HAMID);
    }

    /**
     * 担当者IDを設定する
     *
     * @param val 担当者ID
     */
    public void setHAMID(String val)
    {
        set(Mbj33FunctionControl.HAMID, val);
    }

    /**
     * 機能コードを取得する
     *
     * @return 機能コード
     */
    public String getFUNCCD()
    {
        return (String) get(Mbj33FunctionControl.FUNCCD);
    }

    /**
     * 機能コードを設定する
     *
     * @param val 機能コード
     */
    public void setFUNCCD(String val)
    {
        set(Mbj33FunctionControl.FUNCCD, val);
    }

    /**
     * 機能種別を取得する
     *
     * @return 種別
     */
    public String getFUNCTYPE()
    {
        return (String) get(Mbj33FunctionControl.FUNCTYPE);
    }

    /**
     * 機能種別を設定する
     *
     * @param val 種別
     */
    public void setFUNCTYPE(String val)
    {
        set(Mbj33FunctionControl.FUNCTYPE, val);
    }

    /**
     * 制御を取得する
     *
     * @return 制御
     */
    public String getCONTROL()
    {
        return (String) get(Mbj33FunctionControl.CONTROL);
    }

    /**
     * 制御を設定する
     *
     * @param val 制御
     */
    public void setCONTROL(String val)
    {
        set(Mbj33FunctionControl.CONTROL, val);
    }

    /**
     * 機能名を取得する
     *
     * @return 機能名
     */
    public String getFUNCNM()
    {
        return (String) get(Mbj34FunctionControlItem.FUNCNM);
    }

    /**
     * 機能名を設定する
     *
     * @param val 機能名
     */
    public void setFUNCNM(String val)
    {
        set(Mbj34FunctionControlItem.FUNCNM, val);
    }

    /**
     * フォームファイルIDを取得する
     *
     * @return フォームファイルID
     */
    public String getFORMID()
    {
        return (String) get(Mbj34FunctionControlItem.FORMID);
    }

    /**
     * フォームファイルIDを設定する
     *
     * @param val フォームファイルID
     */
    public void setFORMID(String val)
    {
        set(Mbj34FunctionControlItem.FORMID, val);
    }

    /**
     * オブジェクト名を取得する
     *
     * @return オブジェクト名
     */
    public String getOBJNAME()
    {
        return (String) get(Mbj34FunctionControlItem.OBJNAME);
    }

    /**
     * オブジェクト名を設定する
     *
     * @param val オブジェクト名
     */
    public void setOBJNAME(String val)
    {
        set(Mbj34FunctionControlItem.OBJNAME, val);
    }

    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO()
    {
        return (BigDecimal) get(Mbj34FunctionControlItem.SORTNO);
    }

    /**
     * ソートNoを設定する
     *
     * @param val ソートNo
     */
    public void setSORTNO(BigDecimal val)
    {
        set(Mbj34FunctionControlItem.SORTNO, val);
    }


}
