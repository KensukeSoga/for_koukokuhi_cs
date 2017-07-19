package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.List;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.common.model.Tbj37RdProgramVO;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialVO;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationVO;

/**
 * <P>
 * ラジオ番組登録画面登録情報VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class RegisterRdProgramInfoVO implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ラジオ番組一覧登録用VO */
    private List<Tbj37RdProgramVO> _tbj37InsVo = null;
    /** ラジオ番組一覧更新用VO */
    private List<Tbj37RdProgramVO> _tbj37UpdVo = null;
    /** ラジオ番組一覧削除用VO */
    private List<Tbj37RdProgramVO> _tbj37DelVo = null;

    /** ラジオ番組素材登録用VO */
    private List<Tbj38RdProgramMaterialVO> _tbj38InsVo = null;
    /** ラジオ番組素材更新用VO */
    private List<Tbj38RdProgramMaterialVO> _tbj38UpdVo = null;
    /** ラジオ番組素材削除用VO */
    private List<Tbj38RdProgramMaterialVO> _tbj38DelVo = null;

    /** ラジオ番組ネット局登録用VO */
    private List<Tbj39RdProgramStationVO> _tbj39InsVo = null;
    /** ラジオ番組ネット局削除用VO */
    private List<Tbj39RdProgramStationVO> _tbj39DelVo = null;

    /** 素材一覧更新用VO */
    private List<Tbj20SozaiKanriListVO> _tbj20UpdVo = null;

    /** 担当者ID */
    private String _hamid = null;

    /** ダミープロパティ */
    private String _dummy;

    /**
     * ラジオ番組一覧登録用VOを取得する
     * @return List<Tbj37RdProgramVO> ラジオ番組一覧登録用VO
     */
    public List<Tbj37RdProgramVO> getTbj37InsVo() {
        return _tbj37InsVo;
    }

    /**
     * ラジオ番組一覧登録用VOを設定する
     * @param vo List<Tbj37RdProgramVO> ラジオ番組一覧登録用VO
     */
    public void setTbj37InsVo(List<Tbj37RdProgramVO> vo) {
        _tbj37InsVo = vo;
    }

    /**
     * ラジオ番組一覧更新用VOを取得する
     * @return List<Tbj37RdProgramVO> ラジオ番組一覧更新用VO
     */
    public List<Tbj37RdProgramVO> getTbj37UpdVo() {
        return _tbj37UpdVo;
    }

    /**
     * ラジオ番組一覧更新用VOを設定する
     * @param vo List<Tbj37RdProgramVO> ラジオ番組一覧更新用VO
     */
    public void setTbj37UpdVo(List<Tbj37RdProgramVO> vo) {
        _tbj37UpdVo = vo;
    }

    /**
     * ラジオ番組一覧削除用VOを取得する
     * @return List<Tbj37RdProgramVO> ラジオ番組一覧削除用VO
     */
    public List<Tbj37RdProgramVO> getTbj37DelVo() {
        return _tbj37DelVo;
    }

    /**
     * ラジオ番組一覧削除用VOを設定する
     * @param vo List<Tbj37RdProgramVO> ラジオ番組一覧削除用VO
     */
    public void setTbj37DelVo(List<Tbj37RdProgramVO> vo) {
        _tbj37DelVo = vo;
    }

    /**
     * ラジオ番組素材登録用VOを取得する
     * @return List<Tbj38RdProgramMaterialVO> ラジオ番組素材登録用VO
     */
    public List<Tbj38RdProgramMaterialVO> getTbj38InsVo() {
        return _tbj38InsVo;
    }

    /**
     * ラジオ番組素材登録用VOを設定する
     * @param vo List<Tbj38RdProgramMaterialVO> ラジオ番組素材登録用VO
     */
    public void setTbj38InsVo(List<Tbj38RdProgramMaterialVO> vo) {
        _tbj38InsVo = vo;
    }

    /**
     * ラジオ番組素材更新用VOを取得する
     * @return List<Tbj38RdProgramMaterialVO> ラジオ番組素材更新用VO
     */
    public List<Tbj38RdProgramMaterialVO> getTbj38UpdVo() {
        return _tbj38UpdVo;
    }

    /**
     * ラジオ番組素材更新用VOを設定する
     * @param vo List<Tbj38RdProgramMaterialVO> ラジオ番組素材更新用VO
     */
    public void setTbj38UpdVo(List<Tbj38RdProgramMaterialVO> vo) {
        _tbj38UpdVo = vo;
    }

    /**
     * ラジオ番組素材削除用VOを取得する
     * @return List<Tbj38RdProgramMaterialVO> ラジオ番組素材削除用VO
     */
    public List<Tbj38RdProgramMaterialVO> getTbj38DelVo() {
        return _tbj38DelVo;
    }

    /**
     * ラジオ番組素材削除用VOを設定する
     * @param vo List<Tbj38RdProgramMaterialVO> ラジオ番組素材削除用VO
     */
    public void setTbj38DelVo(List<Tbj38RdProgramMaterialVO> vo) {
        _tbj38DelVo = vo;
    }

    /**
     * ラジオ番組ネット局登録用VOを取得する
     * @return List<Tbj39RdProgramStationVO> ラジオ番組ネット局登録用VO
     */
    public List<Tbj39RdProgramStationVO> getTbj39InsVo() {
        return _tbj39InsVo;
    }

    /**
     * ラジオ番組ネット局登録用VOを設定する
     * @param vo List<Tbj39RdProgramStationVO> ラジオ番組ネット局登録用VO
     */
    public void setTbj39InsVo(List<Tbj39RdProgramStationVO> vo) {
        _tbj39InsVo = vo;
    }

    /**
     * ラジオ番組ネット局削除用VOを取得する
     * @return List<Tbj39RdProgramStationVO> ラジオ番組ネット局削除用VO
     */
    public List<Tbj39RdProgramStationVO> getTbj39DelVo() {
        return _tbj39DelVo;
    }

    /**
     * ラジオ番組ネット局削除用VOを設定する
     * @param vo List<Tbj39RdProgramStationVO> ラジオ番組ネット局削除用VO
     */
    public void setTbj39DelVo(List<Tbj39RdProgramStationVO> vo) {
        _tbj39DelVo = vo;
    }

    /**
     * 素材一覧更新用VOを取得する
     * @return List<Tbj20SozaiKanriListVO> 素材一覧更新用VO
     */
    public List<Tbj20SozaiKanriListVO> getTbj20UpdVo() {
        return _tbj20UpdVo;
    }

    /**
     * 素材一覧更新用VOを設定する
     * @param vo List<Tbj20SozaiKanriListVO> 素材一覧更新用VO
     */
    public void setTbj20UpdVo(List<Tbj20SozaiKanriListVO> vo) {
        _tbj20UpdVo = vo;
    }

    /**
     * 担当者IDを取得する
     * @return String 担当者ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * 担当者IDを設定する
     * @param val String 担当者ID
     */
    public void setHamid(String val) {
        _hamid = val;
    }

    /**
     * ダミープロパティを返します
     * @return String ダミープロパティ
     */
    public String get_dummy() {
        return _dummy;
    }

    /**
     * ダミープロパティを設定する
     * @param val String ダミープロパティ
     */
    public void set_dummy(String val) {
        _dummy = val;
    }
}
