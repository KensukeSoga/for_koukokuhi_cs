package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 媒体パターン表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceMediaPatternDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 媒体パターン登録データVO */
    private RegistMbj35MediaPatternVO _mediaPatternVO = null;

    /** 媒体パターン内容登録データVO */
    private RegistMbj36MediaPatternItemVO _mediaPatternItemVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceMediaPatternDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceMediaPatternDispVO();
    }

    /**
     * 媒体パターン登録データVOを設定します
     * @param vo セットする _mediaPatternVO
     */
    public void setMediaPatternVO(RegistMbj35MediaPatternVO vo)
    {
        _mediaPatternVO = vo;
    }

    /**
     * 媒体パターン登録データVOを取得します
     * @return _mediaPatternVO
     */
    public RegistMbj35MediaPatternVO getMediaPatternVO()
    {
        return _mediaPatternVO;
    }

    /**
     * 媒体パターン内容登録データVOを設定します
     * @param vo セットする _mediaPatternItemVO
     */
    public void setMediaPatternItemVO(RegistMbj36MediaPatternItemVO vo)
    {
        _mediaPatternItemVO = vo;
    }

    /**
     * 媒体パターン内容登録データVOを取得します
     * @return _mediaPatternItemVO
     */
    public RegistMbj36MediaPatternItemVO getMediaPatternItemVO()
    {
        return _mediaPatternItemVO;
    }

}
