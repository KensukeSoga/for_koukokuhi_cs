package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.DummyNull;
import jp.co.isid.nj.model.ModelUtils;

/**
*
* <P>
* �c�ƍ�Ƒ䒠�̏��擾DAO
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2012/12/03 HLC H.Watabe)<BR>
* </P>
*
* @author HLC H.watabe
*/

public class FindAuthorityAccountBookDAO extends AbstractRdbDao {

    /** �f�[�^�������� */
    private FindAuthorityAccountBookCondition _cond;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindAuthorityAccountBookDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[��Ԃ��܂�
     *
     * @return String[] �v���C�}���L�[
     */
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        // new String[] {};
        return null;
    }

    /**
     * �e�[�u������Ԃ��܂�
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj02EigyoDaicho.TBNAME;
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj12Campaign.CAMPCD
                ,Tbj01MediaPlan.MEDIAPLANNO
                ,Tbj02EigyoDaicho.DAICHONO
                ,Tbj02EigyoDaicho.IMPKEY
                ,Tbj02EigyoDaicho.SEIKYUYM
                ,Tbj02EigyoDaicho.MEDIACD
                ,Tbj02EigyoDaicho.MEDIASCD
                ,Tbj02EigyoDaicho.MEDIASNM
                ,Tbj02EigyoDaicho.KEIRETSUCD
                ,Tbj02EigyoDaicho.DCARCD
                ,Tbj02EigyoDaicho.HIYOUNO
                ,Tbj02EigyoDaicho.KIKAKUNO
                ,Tbj02EigyoDaicho.CAMPAIGN
                ,Tbj02EigyoDaicho.NAIYOHIMOKU
                ,Tbj02EigyoDaicho.SPACE
                ,Tbj02EigyoDaicho.NPDIVISION
                ,Tbj02EigyoDaicho.PUBLISHVER
                ,Tbj02EigyoDaicho.SYMBOLDIVISION
                ,Tbj02EigyoDaicho.POSTEDSURFACE
                ,Tbj02EigyoDaicho.UNIT
                ,Tbj02EigyoDaicho.CONTRACTDIVISION
                ,Tbj02EigyoDaicho.KIKANFROM
                ,Tbj02EigyoDaicho.KIKANTO
                ,Tbj02EigyoDaicho.GENKAFLG
                ,Tbj02EigyoDaicho.GROSS
                ,Tbj02EigyoDaicho.DNEBIKIRITSU
                ,Tbj02EigyoDaicho.DNEBIKIGAKU
                ,Tbj02EigyoDaicho.HMCOST
                ,Tbj02EigyoDaicho.APLRIEKIRITSU
                ,Tbj02EigyoDaicho.APLRIEKIGAKU
                ,Tbj02EigyoDaicho.MEDIAHARAI
                ,Tbj02EigyoDaicho.MEDIAMARGINRITSU
                ,Tbj02EigyoDaicho.MEDIAMARGINGAKU
                ,Tbj02EigyoDaicho.MEDIAGENKA
                ,Tbj02EigyoDaicho.TORIRIEKI
                ,Tbj02EigyoDaicho.RIEKIHAIBUN
                ,Tbj02EigyoDaicho.NAIKINRIEKI
                ,Tbj02EigyoDaicho.FURIKAERIEKI
                ,Tbj02EigyoDaicho.EIGYOYOIN
                ,Tbj02EigyoDaicho.FURIKAERIEKI2
                ,Tbj02EigyoDaicho.TVTMEDIATANKA
                ,Tbj02EigyoDaicho.TVTHMTANKA
                ,Tbj02EigyoDaicho.COLORFEE
                ,Tbj02EigyoDaicho.DESIGNATIONFEE
                ,Tbj02EigyoDaicho.DOUBLEFEE
                ,Tbj02EigyoDaicho.RECLASSIFICATIONFEE
                ,Tbj02EigyoDaicho.SPACEFEE
                ,Tbj02EigyoDaicho.SPLITRUNFEE
                ,Tbj02EigyoDaicho.REQUESTDESTINATION
                ,Tbj02EigyoDaicho.BRDDATE
                ,Tbj02EigyoDaicho.BIKO
                ,Tbj02EigyoDaicho.SEIKYUFLG
                ,Tbj02EigyoDaicho.CPDATE
                ,Tbj02EigyoDaicho.BRDSEC
                ,Tbj02EigyoDaicho.FILEOUTFLG
                ,Tbj02EigyoDaicho.APPEARANCEDATE
                ,Tbj02EigyoDaicho.SORTNO
                ,Tbj02EigyoDaicho.CRTDATE
                ,Tbj02EigyoDaicho.CRTNM
                ,Tbj02EigyoDaicho.CRTAPL
                ,Tbj02EigyoDaicho.CRTID
                ,Tbj02EigyoDaicho.UPDDATE
                ,Tbj02EigyoDaicho.UPDNM
                ,Tbj02EigyoDaicho.UPDAPL
                ,Tbj02EigyoDaicho.UPDID
                ,Mbj05Car.CARNM
                ,Mbj03Media.MEDIANM
                ,Mbj10MediaSec.AUTHORITY
                ,Mbj11CarSec.AUTHORITY};
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return getAuthorityAccountBook();
    }

    /**
     * �c�ƍ�Ƒ䒠��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getAuthorityAccountBook() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //�A�Ԃ��擾
        sql.append(" ROW_NUMBER() OVER (ORDER BY "+ Tbj02EigyoDaicho.SORTNO + "," +Tbj02EigyoDaicho.DAICHONO+") AS ROWNO ,");
        //�L�����y�[���R�[�h�F�L�����y�[�����Ŏ擾
        sql.append(" " + Tbj12Campaign.CAMPCD + " || '�F' || " + Tbj12Campaign.CAMPNM + " AS DISPCAMPCD, ");
        //�}�̏󋵊Ǘ�No�F�����Ŏ擾
        sql.append(" " + Tbj01MediaPlan.MEDIAPLANNO + " || '�F' || " + Tbj01MediaPlan.KENMEI + " AS DISPMEDIAPLANNO, ");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        //0�Œ�ŕԂ�
        sql.append(" , 0 AS UPDFLG " );
        sql.append(" FROM ");
        sql.append(" "+ getTableName() + ", ");
        sql.append(" Tbj01MediaPlan, ");
        sql.append(" Tbj12Campaign, ");
        sql.append(" Mbj03Media, ");
        sql.append(" Mbj05Car, ");
        sql.append(" Mbj10MediaSec, ");
        sql.append(" Mbj11CarSec ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO + " = " + Tbj01MediaPlan.MEDIAPLANNO +"(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " = " + Mbj03Media.MEDIACD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DCARCD + " = " + Mbj05Car.DCARCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj01MediaPlan.CAMPCD + " = " + Tbj12Campaign.CAMPCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Mbj03Media.MEDIACD + " = " + Mbj10MediaSec.MEDIACD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + Mbj05Car.DCARCD + " = " + Mbj11CarSec.DCARCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + Mbj10MediaSec.HAMID + " = '" + _cond.getHamid() +"' ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.HAMID + " = '" + _cond.getHamid() +"' ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.SECTYPE + " = 0 ");
        sql.append(" AND ");
        sql.append(" " + Mbj10MediaSec.AUTHORITY + " > 0 ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.AUTHORITY + " > 0 ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.KIKANFROM + " >= '" + _cond.getKikanFrom() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.KIKANTO + " <= '" + _cond.getKikanTo() + "' ");
        if (!_cond.getMediaCd().isEmpty()) {
            sql.append(" AND ");
            sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " ='" + _cond.getMediaCd() +"' ");
        }
        if (!_cond.getDCarCd().isEmpty()) {
            sql.append(" AND ");
            sql.append(" " + Tbj02EigyoDaicho.DCARCD + " ='" + _cond.getDCarCd() +"' ");
        }
        if (!_cond.getMediasNm().isEmpty()) {
            sql.append(" AND ");
            sql.append(" " + Tbj02EigyoDaicho.MEDIASNM + " LIKE('%" + _cond.getMediasNm() +"%') ");
        }
        if (!_cond.getCampNm().isEmpty()) {
            sql.append(" AND ");
            sql.append(" " + Tbj02EigyoDaicho.CAMPAIGN + " LIKE('%" + _cond.getCampNm() +"%') ");
        }
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj02EigyoDaicho.SORTNO + ", ");
        sql.append(" " + Tbj02EigyoDaicho.DAICHONO + " ");

        return sql.toString();
    }

    /**
     * �c�ƍ�Ƒ䒠�̌������s���܂�
     *
     * @return �L�����y�[���ꗗVO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindAuthorityAccountBookVO> findAuthorityAccountBookByCond(FindAuthorityAccountBookCondition cond) throws HAMException {

        super.setModel(new FindAuthorityAccountBookVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * Model�̐������s��<br>
     * �������ʂ�VO��KEY���啶���̂��ߕϊ��������s��<br>
     * AbstractRdbDao��createFindedModelInstances���I�[�o�[���C�h<br>
     *
     * @param hashList
     *            List ��������
     * @return List<FindAuthorityAccountBookVO> �ϊ���̌�������
     */
    @Override
    protected List<FindAuthorityAccountBookVO> createFindedModelInstances(List hashList) {

        List<FindAuthorityAccountBookVO> list = new ArrayList<FindAuthorityAccountBookVO>();

        if (getModel() instanceof FindAuthorityAccountBookVO) {

            for (int i = 0; i < hashList.size(); i++) {

                Map result = (Map) hashList.get(i);
                FindAuthorityAccountBookVO vo = new FindAuthorityAccountBookVO();

                vo.setROWNO((BigDecimal)result.get("ROWNO"));
                vo.setDISPCAMPCD((String)result.get("DISPCAMPCD"));
                vo.setDISPMEDIAPLANNO((String)result.get("DISPMEDIAPLANNO"));
                vo.setCAMPCD((String)result.get(Tbj12Campaign.CAMPCD.toUpperCase()));
                vo.setMEDIAPLANNO((BigDecimal)result.get(Tbj01MediaPlan.MEDIAPLANNO.toUpperCase()));
                vo.setDAICHONO((String)result.get(Tbj02EigyoDaicho.DAICHONO.toUpperCase()));
                vo.setIMPKEY((String)result.get(Tbj02EigyoDaicho.IMPKEY.toUpperCase()));
                vo.setSEIKYUYM((Date)result.get(Tbj02EigyoDaicho.SEIKYUYM.toUpperCase()));
                vo.setMEDIACD((String)result.get(Tbj02EigyoDaicho.MEDIACD.toUpperCase()));
                vo.setMEDIASCD((String)result.get(Tbj02EigyoDaicho.MEDIASCD.toUpperCase()));
                vo.setMEDIASNM((String)result.get(Tbj02EigyoDaicho.MEDIASNM.toUpperCase()));
                vo.setKEIRETSUCD((String)result.get(Tbj02EigyoDaicho.KEIRETSUCD.toUpperCase()));
                vo.setDCARCD((String)result.get(Tbj02EigyoDaicho.DCARCD.toUpperCase()));
                vo.setHIYOUNO((String)result.get(Tbj02EigyoDaicho.HIYOUNO.toUpperCase()));
                vo.setKIKAKUNO((String)result.get(Tbj02EigyoDaicho.KIKAKUNO.toUpperCase()));
                vo.setCAMPAIGN((String)result.get(Tbj02EigyoDaicho.CAMPAIGN.toUpperCase()));
                vo.setNAIYOHIMOKU((String)result.get(Tbj02EigyoDaicho.NAIYOHIMOKU.toUpperCase()));
                vo.setSPACE((String)result.get(Tbj02EigyoDaicho.SPACE.toUpperCase()));
                vo.setNPDIVISION((String)result.get(Tbj02EigyoDaicho.NPDIVISION.toUpperCase()));
                vo.setPUBLISHVER((String)result.get(Tbj02EigyoDaicho.PUBLISHVER.toUpperCase()));
                vo.setSYMBOLDIVISION((String)result.get(Tbj02EigyoDaicho.SYMBOLDIVISION.toUpperCase()));
                vo.setPOSTEDSURFACE((String)result.get(Tbj02EigyoDaicho.POSTEDSURFACE.toUpperCase()));
                vo.setUNIT((String)result.get(Tbj02EigyoDaicho.UNIT.toUpperCase()));
                vo.setCONTRACTDIVISION((String)result.get(Tbj02EigyoDaicho.CONTRACTDIVISION.toUpperCase()));
                vo.setKIKANFROM((Date)result.get(Tbj02EigyoDaicho.KIKANFROM.toUpperCase()));
                vo.setKIKANTO((Date)result.get(Tbj02EigyoDaicho.KIKANTO.toUpperCase()));
                vo.setGENKAFLG((String)result.get(Tbj02EigyoDaicho.GENKAFLG.toUpperCase()));
                vo.setGROSS((BigDecimal)result.get(Tbj02EigyoDaicho.GROSS.toUpperCase()));
                vo.setDNEBIKIRITSU((BigDecimal)result.get(Tbj02EigyoDaicho.DNEBIKIRITSU.toUpperCase()));
                vo.setDNEBIKIGAKU((BigDecimal)result.get(Tbj02EigyoDaicho.DNEBIKIGAKU.toUpperCase()));
                vo.setHMCOST((BigDecimal)result.get(Tbj02EigyoDaicho.HMCOST.toUpperCase()));
                vo.setAPLRIEKIRITSU((BigDecimal)result.get(Tbj02EigyoDaicho.APLRIEKIRITSU.toUpperCase()));
                vo.setAPLRIEKIGAKU((BigDecimal)result.get(Tbj02EigyoDaicho.APLRIEKIGAKU.toUpperCase()));
                vo.setMEDIAHARAI((BigDecimal)result.get(Tbj02EigyoDaicho.MEDIAHARAI.toUpperCase()));
                vo.setMEDIAMARGINRITSU((BigDecimal)result.get(Tbj02EigyoDaicho.MEDIAMARGINRITSU.toUpperCase()));
                vo.setMEDIAMARGINGAKU((BigDecimal)result.get(Tbj02EigyoDaicho.MEDIAMARGINGAKU.toUpperCase()));
                vo.setMEDIAGENKA((BigDecimal)result.get(Tbj02EigyoDaicho.MEDIAGENKA.toUpperCase()));
                vo.setTORIRIEKI((BigDecimal)result.get(Tbj02EigyoDaicho.TORIRIEKI.toUpperCase()));
                vo.setRIEKIHAIBUN((BigDecimal)result.get(Tbj02EigyoDaicho.RIEKIHAIBUN.toUpperCase()));
                vo.setNAIKINRIEKI((BigDecimal)result.get(Tbj02EigyoDaicho.NAIKINRIEKI.toUpperCase()));
                vo.setFURIKAERIEKI((BigDecimal)result.get(Tbj02EigyoDaicho.FURIKAERIEKI.toUpperCase()));
                vo.setEIGYOYOIN((BigDecimal)result.get(Tbj02EigyoDaicho.EIGYOYOIN.toUpperCase()));
                vo.setFURIKAERIEKI2((BigDecimal)result.get(Tbj02EigyoDaicho.FURIKAERIEKI2.toUpperCase()));
                vo.setTVTMEDIATANKA((BigDecimal)result.get(Tbj02EigyoDaicho.TVTMEDIATANKA.toUpperCase()));
                vo.setTVTHMTANKA((BigDecimal)result.get(Tbj02EigyoDaicho.TVTHMTANKA.toUpperCase()));
                vo.setCOLORFEE((BigDecimal)result.get(Tbj02EigyoDaicho.COLORFEE.toUpperCase()));
                vo.setDESIGNATIONFEE((BigDecimal)result.get(Tbj02EigyoDaicho.DESIGNATIONFEE.toUpperCase()));
                vo.setDOUBLEFEE((BigDecimal)result.get(Tbj02EigyoDaicho.DOUBLEFEE.toUpperCase()));
                vo.setRECLASSIFICATIONFEE((BigDecimal)result.get(Tbj02EigyoDaicho.RECLASSIFICATIONFEE.toUpperCase()));
                vo.setSPACEFEE((BigDecimal)result.get(Tbj02EigyoDaicho.SPACEFEE.toUpperCase()));
                vo.setSPLITRUNFEE((BigDecimal)result.get(Tbj02EigyoDaicho.SPLITRUNFEE.toUpperCase()));
                vo.setREQUESTDESTINATION((String)result.get(Tbj02EigyoDaicho.REQUESTDESTINATION.toUpperCase()));
                vo.setBRDDATE((String)result.get(Tbj02EigyoDaicho.BRDDATE.toUpperCase()));
                vo.setBIKO((String)result.get(Tbj02EigyoDaicho.BIKO.toUpperCase()));
                vo.setSEIKYUFLG((String)result.get(Tbj02EigyoDaicho.SEIKYUFLG.toUpperCase()));
                vo.setCPDATE((String)result.get(Tbj02EigyoDaicho.CPDATE.toUpperCase()));
                vo.setBRDSEC((BigDecimal)result.get(Tbj02EigyoDaicho.BRDSEC.toUpperCase()));
                vo.setFILEOUTFLG((String)result.get(Tbj02EigyoDaicho.FILEOUTFLG.toUpperCase()));
                if (!(result.get(Tbj02EigyoDaicho.APPEARANCEDATE.toUpperCase()) instanceof DummyNull))
                {
                    vo.setAPPEARANCEDATE((Date)result.get(Tbj02EigyoDaicho.APPEARANCEDATE.toUpperCase()));
                }
                vo.setSORTNO((BigDecimal)result.get(Tbj02EigyoDaicho.SORTNO.toUpperCase()));
                vo.setCRTDATE((Date)result.get(Tbj02EigyoDaicho.CRTDATE.toUpperCase()));
                vo.setCRTNM((String)result.get(Tbj02EigyoDaicho.CRTNM.toUpperCase()));
                vo.setCRTAPL((String)result.get(Tbj02EigyoDaicho.CRTAPL.toUpperCase()));
                vo.setCRTID((String)result.get(Tbj02EigyoDaicho.CRTID.toUpperCase()));
                vo.setUPDDATE((Date)result.get(Tbj02EigyoDaicho.UPDDATE.toUpperCase()));
                vo.setUPDNM((String)result.get(Tbj02EigyoDaicho.UPDNM.toUpperCase()));
                vo.setUPDAPL((String)result.get(Tbj02EigyoDaicho.UPDAPL.toUpperCase()));
                vo.setUPDID((String)result.get(Tbj02EigyoDaicho.UPDID.toUpperCase()));
                vo.setMEDIANM((String)result.get(Mbj03Media.MEDIANM.toUpperCase()));
                vo.setMEDIAAUTHORITY((String)result.get(Mbj10MediaSec.AUTHORITY.toUpperCase()));
                vo.setCARAUTHORITY((String)result.get(Mbj11CarSec.AUTHORITY.toUpperCase()));
                vo.setUPDFLG((BigDecimal)result.get("UPDFLG"));

                // �������ʒ���̏�Ԃɂ���
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}