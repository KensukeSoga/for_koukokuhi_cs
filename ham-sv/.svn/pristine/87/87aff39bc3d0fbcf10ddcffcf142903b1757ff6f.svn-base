package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 媒体パターン表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMediaPatternDispResult extends AbstractServiceResult
{
    /** 媒体パターン検索データVO */
    private FindMbj35MediaPatternVO _mediaPatternVO = null;

    /** 媒体パターン内容検索データVO */
    private FindMbj36MediaPatternItemVO _mediaPatternItemVO = null;

    /** 新雑媒体マスタ検索データVO */
    private FindMasterMaintenanceMEU20MSMZBTVO _mEU20MSMZBTVO = null;

    /**
     * 媒体パターン検索データVOを設定します
     * @param vo セットする _mediaPatternVO
     */
    public void setMediaPatternVO(FindMbj35MediaPatternVO vo)
    {
        _mediaPatternVO = vo;
    }

    /**
     * 媒体パターン検索データVOを取得します
     * @return _mediaPatternVO
     */
    public FindMbj35MediaPatternVO getMediaPatternVO()
    {
        return _mediaPatternVO;
    }

    /**
     * 媒体パターン内容検索データVOを設定します
     * @param vo セットする _mediaPatternItemVO
     */
    public void setMediaPatternItemVO(FindMbj36MediaPatternItemVO vo)
    {
        _mediaPatternItemVO = vo;
    }

    /**
     * 媒体パターン内容検索データVOを取得します
     * @return _mediaPatternItemVO
     */
    public FindMbj36MediaPatternItemVO getMediaPatternItemVO()
    {
        return _mediaPatternItemVO;
    }

    /**
     * 新雑媒体マスタ検索データVOを設定します
     * @param vo セットする _mEU20MSMZBTVO
     */
    public void setMEU20MSMZBTVO(FindMasterMaintenanceMEU20MSMZBTVO vo)
    {
        _mEU20MSMZBTVO = vo;
    }

    /**
     * 新雑媒体マスタ検索データVOを取得します
     * @return _mEU20MSMZBTVO
     */
    public FindMasterMaintenanceMEU20MSMZBTVO getMEU20MSMZBTVO()
    {
        return _mEU20MSMZBTVO;
    }

}
