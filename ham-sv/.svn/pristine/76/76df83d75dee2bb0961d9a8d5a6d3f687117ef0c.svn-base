package jp.co.isid.ham.common.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 起動処理実行結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class StartUpResult extends AbstractServiceResult {

    /**
     * ユーザーマスタVOリスト
     */
    private List<Mbj02UserVO> _mbj02vo;

    /**
     * コードマスタVOリスト
     */
    private List<Mbj12CodeVO> _mbj12vo;

    /**
     * システム使用状況VOリスト
     */
    private List<Mbj01SysStsVO> _mbj01vo;

    /**
     * 新HAM向けVIEW(個人情報)VOリスト
     */
    private List<Vbj01AccUserVO> _vbj01vo;

    /**
     * 管理テーブルVOリスト
     */
    private List<Tbj35KnrVO> _tbj35vo;

    /**
     * 経理組織展開テーブル
     */
    private List<RepaVbjaMeu07SikKrSprdVO> _sikKrSprdVo;


    /**
     * ユーザーマスタVOリストを取得します
     * @return ユーザーマスタVOリスト
     */
    public List<Mbj02UserVO> getUserList() {
        return _mbj02vo;
    }

    /**
     * ユーザーマスタVOリストを設定します
     * @param mbj02vo ユーザーマスタVOリスト
     */
    public void setUserList(List<Mbj02UserVO> mbj02vo) {
        _mbj02vo = mbj02vo;
    }

    /**
     * コードマスタVOリストを取得します
     * @return  コードマスタVOリスト
     */
    public List<Mbj12CodeVO> getCodeList() {
        return _mbj12vo;
    }

    /**
     * コードマスタVOリストを設定します
     * @param mbj12vo  コードマスタVOリスト
     */
    public void setCodeList(List<Mbj12CodeVO> mbj12vo) {
        _mbj12vo = mbj12vo;
    }

    /**
     * システム使用状況VOリストを取得します
     * @return システム使用状況VOリスト
     */
    public List<Mbj01SysStsVO> getSysStsList() {
        return _mbj01vo;
    }

    /**
     * システム使用状況VOリストを設定します
     * @param mbj01vo システム使用状況VOリスト
     */
    public void setSysStsList(List<Mbj01SysStsVO> mbj01vo) {
        _mbj01vo = mbj01vo;
    }

    /**
     * 新HAM向けVIEW(個人情報)VOリストを取得します
     * @return 新HAM向けVIEW(個人情報)
     */
    public List<Vbj01AccUserVO> getAccUserList() {
        return _vbj01vo;
    }

    /**
     * 新HAM向けVIEW(個人情報)VOリストを設定します
     * @param vbj01vo 新HAM向けVIEW(個人情報)
     */
    public void setAccUserList(List<Vbj01AccUserVO> vbj01vo) {
        _vbj01vo = vbj01vo;
    }

    /**
     * 管理テーブルVOリストを取得します
     * @return 管理テーブル
     */
    public List<Tbj35KnrVO> getKnrList() {
        return _tbj35vo;
    }

    /**
     * 管理テーブルVOリストを設定します
     * @param tbj35vo 管理テーブル
     */
    public void setKnrList(List<Tbj35KnrVO> tbj35vo) {
        _tbj35vo = tbj35vo;
    }

    /**
     * 経理組織展開テーブルを取得します
     * @return 経理組織展開テーブル
     */
    public List<RepaVbjaMeu07SikKrSprdVO>  getSikKrSprd() {
        return _sikKrSprdVo;
    }

    /**
     * 経理組織展開テーブルを設定します
     * @param sikKrSprdVo 経理組織展開テーブル
     */
    public void setSikKrSprd(List<RepaVbjaMeu07SikKrSprdVO> sikKrSprdVo) {
        _sikKrSprdVo = sikKrSprdVo;
    }
}
